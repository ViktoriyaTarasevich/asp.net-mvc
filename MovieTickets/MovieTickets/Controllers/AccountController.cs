﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using DataAccess.UnitOfWork;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MovieTickets.App_Start;
using MovieTickets.Models;
using MovieTickets.ViewModels;

namespace MovieTickets.Controllers
{

    public class AccountController : Controller
    {
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ??  HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public  ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LogInViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.Name, model.Password);
                if (user != null)
                {
                    
                    await SignInAsync(user, model.RememberMe);
                    
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {UserName = model.Name, Email = model.Email, FirstName = model.Name, SurName = model.SurName};
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            var uow = new UnitOfWork<MovieTicketContext>();
            var repository = uow.GetRepository<IpStory>();
            if (User.Identity.GetUserId() != null)
            {
                repository.Insert(new IpStory()
                {
                    Time = DateTime.Now,
                    Ip = Request.UserHostAddress,
                    ApplicationUserId = User.Identity.GetUserId()
                });
            }

            uow.Save();
            AuthenticationManager.SignOut();
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Manage()
        {
            var uow = new UnitOfWork<MovieTicketContext>();
           
            
            var userRepository = uow.GetRepository<ApplicationUser>();
            var userinf = userRepository.GetById(User.Identity.GetUserId());
            var model = new ManageUserViewModel()
            {
                SurName = userinf.SurName,
                Email = userinf.Email,
                IpStories = userinf.IpStories
            };

            return View(model);
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            bool hasPassword = HasPassword();
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasPassword)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        
                        var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                        await SignInAsync(user, false);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    AddErrors(result);
                }
            }
            
            return View(model);
        }

        [Authorize]
        public ActionResult Backet(string id)
        {
            if (id == User.Identity.GetUserId())
            {
                var uow = new UnitOfWork<MovieTicketContext>();
                var repository = uow.GetRepository<Ticket>();
                var tickets = repository.GetAll().Where(ticket => ticket.ApplicationUserId == id).ToList();
                var placesRepository = uow.GetRepository<Place>();
                var seanceRepository = uow.GetRepository<Seance>();
                var filmRepository = uow.GetRepository<Film>();
                var priceRepository = uow.GetRepository<TicketPrice>();
                var ticketCategoryRepository = uow.GetRepository<TicketCategory>();
                var ticketsModel = (from ticket in tickets
                    let place = placesRepository.GetById(ticket.PlaceId)
                    let seance = seanceRepository.GetById(ticket.SeanceId)
                    let film = filmRepository.GetById(seance.FilmId)
                    let price = priceRepository.GetById(seance.TicketPriceId)
                    let category = ticketCategoryRepository.GetById(place.TicketCategoryId)
                    select new TicketViewModels
                    {
                        Id = ticket.Id, Row = place.Row, Column = place.Col, Film = film.Title, Price = price.Price*category.PriceCoef
                    }).ToList();
                return View(ticketsModel);
            }
            return Redirect("Error");
        }

        #region Helpers

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            var givenName = user.FirstName;

            identity.AddClaim(new Claim(ClaimTypes.GivenName, givenName));

            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

       
        #endregion
    }
}