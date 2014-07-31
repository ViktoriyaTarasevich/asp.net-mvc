﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using MovieTickets.Context;
using MovieTickets.Entities.Models;
using Microsoft.AspNet.Identity;

namespace MovieTickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Film> _repository;
        private IUnitOfWork<MovieTicketContext> _unitOfWork; 
        public HomeController(IUnitOfWork<MovieTicketContext> uof)
        {
            _unitOfWork = uof;
            _repository = uof.GetRepository<Film>();
            
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            IEnumerable<Film> model = _repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult FilmGalery()
        {
            IEnumerable<Film> model = _repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Film(int id)
        {
            var model = new List<Film> {_repository.GetById(id)};
            return View(model);
        }

        public ActionResult FullTextSearch(string searchString)
        {
            IEnumerable<Film> model = _repository.GetAll();
            var serchaResultModel = model.Where(x => x.Description.Contains(searchString) || x.Title.Contains(searchString)).ToList();

            return View("FilmGalery", serchaResultModel);
        }

        public ActionResult BuyResult()
        {
            var repository = _unitOfWork.GetRepository<Ticket>();
            var tickets = repository.GetAll();
            foreach (var ticket in tickets.Where(ticket => ticket.ApplicationUserId == User.Identity.GetUserId()))
            {
                ticket.IsBought = true;
            }
            _unitOfWork.Save();
            ViewBag.Action = "Потрачено.";
            return View();
        }
    }
}