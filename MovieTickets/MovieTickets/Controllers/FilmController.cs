using System.Web;
using System.Web.Mvc;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using MovieTickets.App_Start;
using MovieTickets.Models;

namespace MovieTickets.Controllers
{
    public class FilmController : Controller
    {
        private UnitOfWork<MovieTicketContext> _unitOfWork;
        private IRepository<Film> _repository;
        public FilmController()
        {
            this._unitOfWork = new UnitOfWork<MovieTicketContext>();
            this._repository = this._unitOfWork.GetRepository<Film>();
        }


        //
        // GET: /Admin/
        public ActionResult FilmControl()
        {
            var model = this._repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this._repository.Delete(this._repository.GetById(id));
            this._unitOfWork.Save();
            var mod = this._repository.GetById(id);
            return RedirectToAction("FilmControl");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Film model, HttpPostedFileBase file)
        {
            model.Image = file.FileName;
            
            return RedirectToAction("NewSeance");
        }


        public ActionResult NewSeance()
        {
            return View();
        }
    }
}