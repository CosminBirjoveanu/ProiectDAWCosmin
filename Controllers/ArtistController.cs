using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProiectDAWCosmin.Models;

namespace ProiectDAWCosmin.Controllers
{
    public class ArtistController : Controller
    {
        private DbCtx db = new DbCtx();
        [HttpGet]
        public ActionResult Index()
        {
            List<Artist> artists = db.Artists.Include("BandWebsite").ToList();
            ViewBag.Artists = artists;

            return View();
        }
    }
}