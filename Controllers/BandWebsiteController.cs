using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProiectDAWCosmin.Models;

namespace ProiectDAWCosmin.Controllers
{
    public class BandWebsiteController : Controller
    {
        private DbCtx db = new DbCtx();
        [HttpGet]
        public ActionResult Index()
        {
            List<BandWebsite> websites = db.BandWebsites.ToList();
            ViewBag.Websites = websites;

            return View();
        }
    }
}