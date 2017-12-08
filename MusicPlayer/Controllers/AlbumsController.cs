using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicPlayer.Models;
using MusicPlayer.ViewModel;

namespace MusicPlayer.Controllers
{
    public class AlbumsController : Controller
    {
        private MusicPlayerContext db = new MusicPlayerContext();

        // GET: Albums
        public ActionResult Index()
        {
            AlbumBusinessLayer abl = new AlbumBusinessLayer();
            return View(abl.GetAlbums());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            AlbumBusinessLayer abl = new AlbumBusinessLayer();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = abl.GetAlbumDetails(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Album album)
        {
            AlbumBusinessLayer abl = new AlbumBusinessLayer();
            if (ModelState.IsValid)
            {
                //db.Albums.Add(album);
                //db.SaveChanges();
                abl.SaveAlbum(album);
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            AlbumBusinessLayer abl = new AlbumBusinessLayer();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = abl.GetAlbum(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Album album)
        {
            AlbumBusinessLayer abl = new AlbumBusinessLayer();
            if (ModelState.IsValid)
            {
                abl.EditAlbum(album); ;
                //db.Entry(album).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            AlbumBusinessLayer abl = new AlbumBusinessLayer();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = abl.GetAlbum(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlbumBusinessLayer abl = new AlbumBusinessLayer();
            Album album = abl.GetAlbum(id);
            //db.Albums.Remove(album);
            //db.SaveChanges();
            abl.DeleteAlbum(album);
            return RedirectToAction("Index");
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GetAlbumsToJSON()
        {
            
            AlbumBusinessLayer abl = new AlbumBusinessLayer();
            List<Album> albums = abl.GetAlbums();
            List<AlbumData> AlbumDataList = new List<AlbumData>();
            foreach (Album album in albums)
            {
                AlbumDataList.Add(new AlbumData(){Id=album.Id, Name = album.Name});
            }
            
            return Json(AlbumDataList);
        }
        
    }
}
