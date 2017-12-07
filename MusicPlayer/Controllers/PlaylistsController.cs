using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using MusicPlayer.Models;
using MusicPlayer.ViewModel;

namespace MusicPlayer.Controllers
{
    public class PlaylistsController : Controller
    {
        private MusicPlayerContext db = new MusicPlayerContext();

        // GET: Playlists
        public ActionResult Index()
        {
            var LoggedUser = User.Identity.Name;
            //if(LoggedUser != "")
            //{
                //var PlayerUser = db.PlayerUsers.Where(p => p.Name == LoggedUser);
                var Playlists = db.Playlists.SqlQuery("Select * From Playlists where user_Id in " +
                    "(select Id from PlayerUsers where Name = {0})", LoggedUser);
                //ViewBag.Playlists = db.Playlists.Where(x => x.user == PlayerUser).ToList();
                return View(Playlists);
          //  }
           // return View();
            //return View(db.Playlists.ToList());
        }

        // GET: Playlists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new PlaylistIndexData();
            //Playlist playlist = db.Playlists.Find(id);
            var playlist = db.Playlists.Find(id);
            viewModel.Playlist = playlist;
            var songs = db.Songs.Include(d => d.Author).Include(d => d.Album);
            List<Song> SongList = new List<Song>();
            foreach(Song song in songs)
            {
                if(song.Playlist.Contains(playlist))
                {
                    SongList.Add(song);
                }
            }
            viewModel.Songs = SongList.AsEnumerable();
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Playlists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                var LoggedUser = User.Identity.Name;
                //var PlayerUser = db.PlayerUsers.Where(x => x.Name == LoggedUser).Single();
                playlist.user = db.PlayerUsers.Where(x => x.Name == LoggedUser).Single();
                //playlist.user = PlayerUser;
                db.Playlists.Add(playlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playlist);
        }

        // GET: Playlists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = db.Playlists.Find(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // POST: Playlists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playlist);
        }

        // GET: Playlists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = db.Playlists.Find(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // POST: Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Playlist playlist = db.Playlists.Find(id);
            db.Playlists.Remove(playlist);
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
