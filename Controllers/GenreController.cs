using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProiectDAWCosmin.Models;

namespace ProiectDAWCosmin.Controllers
{
    public class GenreController : Controller
    {
        private DbCtx db = new DbCtx();
        [HttpGet]
        public ActionResult Index()
        {
            List<Genre> genres = db.Genres.ToList();
            ViewBag.Genres = genres;

            return View();
        }
    }
}