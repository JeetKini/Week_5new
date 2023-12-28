using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using VidlysProject.Models;
using VidlysProject.ViewModels;
using System.Data.Entity;


namespace VidlysProject.Controllers
{
    public class MovieController : Controller
    {
        private ApplicatoinDbContext _context;

        public MovieController()
        {
            _context = new ApplicatoinDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {   

            var movies = _context.Movies.Include(g=>g.Genre).ToList();

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
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
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
                Movie=movie,
                movieGenres = _context.MoviesGenres.ToList()
            };

            return View("MovieForm", viewModel);
        }
        //public ActionResult Movies()
        //{
        //    ViewBag.Name = "WorldWar-Z";
        //    return View();
        //}
        //public ActionResult Details()
        //{
        //    ViewBag.Name = "Jeet Kini";



        //    return View();

        //}
        //public ActionResult Edit(int id)
        //{

        //    return Content("id :" + id);
        //}
        //public ActionResult Index1(int? pageIndex, string sortBy)
        //{
        //    if (pageIndex != 0)
        //    {
        //        pageIndex = 1;
        //    }
        //    if (String.IsNullOrEmpty(sortBy))
        //    {
        //        sortBy = "name";
        //    }
        //    return Content(String.Format("pageIndex :{0} sortBy :{1}", pageIndex, sortBy));

        //}
        //public ActionResult CustomerName()
        //{
        //    var customer = new List<Customer> {

        //        new Customer{ Name="Jeet Kini"},
        //        new Customer{ Name="Adnan khan"}
        //    };
        //    var viewmodel = new RamdomMovieViewModel
        //    {


        //        Customers = customer
        //    };
        //    return View(viewmodel);
    }
    }
