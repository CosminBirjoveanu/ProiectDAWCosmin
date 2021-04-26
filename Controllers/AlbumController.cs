using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProiectDAWCosmin.Models;

namespace ProiectDAWCosmin.Controllers
{
    public class AlbumController : Controller
    {
        private DbCtx db = new DbCtx();
        [HttpGet]
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Title";

            List<Album> albums = db.Albums.Include("Label").ToList();
            ViewBag.Albums = albums;

            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Album album = db.Albums
                    .Include(e => e.Artist)
                    .Include(e => e.Label)
                    .Where(e => e.AlbumId == id)
                    .FirstOrDefault();
                if (album != null)
                {
                    return View(album);
                }

                return HttpNotFound("Couldn't find the album with id " + id.ToString() + ".");
            }

            return HttpNotFound("Missing album id parameter.");
        }

        [HttpGet]
        public ActionResult New()
        {
            Album album = new Album();
            album.Genres = new List<Genre>();
            return View(album);
        }

        [HttpPost]
        public ActionResult New(Album albumRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    albumRequest.Label = db.Labels.FirstOrDefault(l => l.LabelId.Equals(14));
                    albumRequest.Artist = db.Artists.FirstOrDefault(a => a.ArtistId.Equals(102));
                    albumRequest.Genres = new List<Genre>()
                    {
                        db.Genres.FirstOrDefault(g => g.GenreId.Equals(1001))
                    };
                    db.Albums.Add(albumRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(albumRequest);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Album album = db.Albums.Find(id);
                if (album == null)
                {
                    return HttpNotFound("Couldn't find the album with id " + id.ToString() + "!");
                }
                return View(album);
            }
            return HttpNotFound("Missing album id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Album albumRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Album Album = db.Albums
                        .SingleOrDefault(b => b.AlbumId.Equals(id));

                    if (TryUpdateModel(Album))
                    {
                        Album.Title = albumRequest.Title;
                        Album.Songs = albumRequest.Songs;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(albumRequest);
            }
            catch (Exception e)
            {
                return View(albumRequest);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Album album = db.Albums.Find(id);
                if (album == null)
                {
                    return HttpNotFound("Couldn't find the album with id " + id.ToString() + "!");
                }
                db.Albums.Remove(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Missing album id parameter!");
        }
    }
}