using NewVidlysProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewVidlysProject.ViewModels;


namespace NewVidlysProject.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext(); 
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {

            var movies = _context.Movies.Include("Genre").ToList();

            return View(movies);


            // return Content("Hello World");
            //return HttpNotFound();
            //  return new EmptyResult();


            // return RedirectToAction("Index","Home",new {page=1,sortby="name"});


        }
        public ActionResult Create()
        {

            var movieGenres = _context.MoviesGenres.ToList();
            var viewModel = new NewMovieViewModel
            {

                movieGenres = movieGenres
            };



            return View("Create", viewModel);

        }


        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel
                {
                    Movie = movie,
                    movieGenres = _context.MoviesGenres.ToList()

                };
                return View("Movies", viewModel);
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include("Genre").SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                movieGenres = _context.MoviesGenres.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}
