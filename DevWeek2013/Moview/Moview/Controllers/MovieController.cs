using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moview.Models;
using Service;

namespace Moview.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            var entities = _service.GetMovies();
            var movies = new List<MovieDetails>();
            foreach (var entity in entities)
            {
                movies.Add(new MovieDetails{Id = entity.Id, Title = entity.MovieTitle, Director = entity.Director});
            }

            return View(movies);
        }

        public ActionResult Get(int? id)
        {
            // get details
            MovieDetails model = new MovieDetails { Title = "Pulp Fiction", Director = "QT" };
            if (Request.IsAjaxRequest())
            {
                return PartialView("_details", model);
            }
            return View(model);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateMovieDetails model)
        {
            if (ModelState.IsValid)
            {
                // add to database                
                return RedirectToAction("Index");
            }
            return View("new", model);
        }
    }
}
