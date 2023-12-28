using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VidlysProject.Controllers
{
    public class HomeController : Controller
    {
        //[Route("Home/HelloBoy")]
        public ActionResult Index()
        {
            //ViewBag.m = "This is View bag";
            //ViewData["mm"] = "This is View Data";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}