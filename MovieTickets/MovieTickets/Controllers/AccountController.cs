using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MovieTickets.App_Start;
using MovieTickets.Entities.Models;
using MovieTickets.Presentation.ViewModels;

namespace MovieTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private ApplicationUserManager _userManager;

        public AccountController(IUnitOfWork uof)
        {
            _unitOfWork = uof;
        }

        public AccountController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
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
                ApplicationUser user = await UserManager.FindAsync(model.Name, model.Password);

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
                var user = new ApplicationUser
                    {
                        UserName = model.Name,
                        Email = model.Email,
                        FirstName = model.Name,
                        SurName = model.SurName
                    };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_unitOfWork.Context));
                if (!roleManager.RoleExists("user"))
                {
                    roleManager.Create(new IdentityRole("user"));
                }
                await UserManager.AddToRoleAsync(user.Id, "user");
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
            IRepository<IpStory> repository = _unitOfWork.GetRepository<IpStory>();
            if (User.Identity.GetUserId() != null)
            {
                repository.Insert(new IpStory
                    {
                        Time = DateTime.Now,
                        Ip = Request.UserHostAddress,
                        ApplicationUserId = User.Identity.GetUserId()
                    });
            }

            _unitOfWork.Save();
            AuthenticationManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Manage()
        {
            IRepository<ApplicationUser> userRepository = _unitOfWork.GetRepository<ApplicationUser>();
            ApplicationUser userinf = userRepository.GetById(User.Identity.GetUserId());
            var model = new ManageUserViewModel
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
                    IdentityResult result =
                        await
                        UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                        await SignInAsync(user, false);
                        return RedirectToAction("Manage", new {Message = ManageMessageId.CHANGE_PASSWORD_SUCCESS});
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
                IRepository<Ticket> repository = _unitOfWork.GetRepository<Ticket>();
                List<Ticket> tickets = repository.GetAll().Where(ticket => ticket.ApplicationUserId == id).ToList();


                List<TicketViewModels> ticketsModel = TicketHelper.GetInformationForBascket(
                    _unitOfWork.GetRepository<TicketPrice>(),
                    _unitOfWork.GetRepository<TicketCategory>(),
                    tickets,
                    _unitOfWork.GetRepository<Film>(),
                    _unitOfWork.GetRepository<Seance>(),
                    _unitOfWork.GetRepository<Place>());

                return View(ticketsModel);
            }
            return Redirect("Error");
        }

        #region Helpers

        public enum ManageMessageId
        {
            CHANGE_PASSWORD_SUCCESS,
            SET_PASSWORD_SUCCESS,
            REMOVE_LOGIN_SUCCESS,
            ERROR
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        private bool HasPassword()
        {
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            ClaimsIdentity identity =
                await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            string givenName = user.FirstName;

            identity.AddClaim(new Claim(ClaimTypes.GivenName, givenName));

            AuthenticationManager.SignIn(new AuthenticationProperties {IsPersistent = isPersistent}, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
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