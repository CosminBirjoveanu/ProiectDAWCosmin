using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProiectDAWCosmin.Models;

namespace ProiectDAWCosmin.Controllers
{
    public class LabelController : Controller
    {
        private DbCtx db = new DbCtx();
        [HttpGet]
        public ActionResult Index()
        {
            List<Label> labels = db.Labels.ToList();
            ViewBag.Labels = labels;

            return View();
        }
    }
}