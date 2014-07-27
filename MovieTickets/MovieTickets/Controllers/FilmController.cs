using System.Web;
using System.Web.Mvc;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using MovieTickets.App_Start;
using MovieTickets.Models;
using MovieTickets.ViewModels;

namespace MovieTickets.Controllers
{
    public class FilmController : Controller
    {
        private UnitOfWork<MovieTicketContext> _unitOfWork;
        private IRepository<Film> _repository;
        private int _newFilmId;
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
            int idFilm = 0;
            this._repository.Insert(model);
            this._unitOfWork.Save();
            this._newFilmId = model.Id;
            var films = this._repository.GetAll();
            foreach (var film in films)
            {
                if (film.Title == model.Title)
                {
                    idFilm = film.Id;
                    break;
                }
            }
            return RedirectToAction("NewSeance",new {id = idFilm});
        }

        public ActionResult NewSeance()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewSeance(SeanceViewModel model,int id)
        {
            var senceRepository = this._unitOfWork.GetRepository<Seance>();
            Seance seance = new Seance() {FilmId = id, Time = model.Time, Date = model.Date};
            senceRepository.Insert(seance);
            this._unitOfWork.Save();
            return View();
        }
    }
}