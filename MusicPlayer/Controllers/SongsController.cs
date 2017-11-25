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
using System.Threading.Tasks;

namespace MusicPlayer.Controllers
{
    public class SongsController : Controller
    {
        private MusicPlayerContext db = new MusicPlayerContext();

        // GET: Songs
        public async Task<ActionResult> Index()
        {
            var songs = db.Songs.Include(d => d.Author);
            var song = db.Songs.Include(d => d.Album);

            var authorResult = await songs.ToListAsync();
            //return View(db.Songs.ToList());
            return View(await song.ToListAsync());
        }

        // GET: Songs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            Author author = db.Authors.Find(song.AuthorId);
            Album album = db.Albums.Find(song.AlbumId);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName"); //bylo Id zamiast AuthorId
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Genre,AuthorId,AlbumId")] Song song) // dorzucone Author
        {
            if (ModelState.IsValid)
            {
                db.Songs.Add(song);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName", song.AuthorId);
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name", song.AlbumId);
            return View(song);
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName"); //bylo Id zamiast AuthorId
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name");
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Genre,AuthorId,AlbumId")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Entry(song).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName", song.AuthorId);
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name", song.AlbumId);
            return View(song);
        }

        // GET: Songs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            Author author = db.Authors.Find(song.AuthorId);
            Album album = db.Albums.Find(song.AlbumId);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Song song = db.Songs.Find(id);
            //Author author = db.Authors.Find(song.AuthorId);
            //Album album = db.Albums.Find(song.AlbumId);
            db.Songs.Remove(song);
            db.SaveChanges();
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
    }
}
