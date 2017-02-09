using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medipol.Exam.Models;

namespace Medipol.Exam.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;

        public HomeController()
        {
            _db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        public ActionResult Index()
        {
            var exams = _db.Exams.Where(t => t.Active == true).ToList();
            return View(exams);
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