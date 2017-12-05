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
        public ActionResult Index(int? id, int? playlistId)
        {
            var viewModel = new SongIndexData();
            viewModel.Songs = db.Songs.Include(d => d.Author).Include(d => d.Album);

            if(id != null)
            {
                //string query = "SELECT * FROM Playlists";
                //ViewBag.SongId = id.Value;
                viewModel.Playlists = db.Playlists.SqlQuery("SELECT * FROM Playlists");
            }

            if(playlistId != null)
            {
                
                ViewBag.PlaylistId = playlistId.Value;
                var song = db.Songs.Find(id);
                var playlist = db.Playlists.SqlQuery("SELECT * FROM Playlists WHERE Id = {0}", playlistId).Single();
                if (!playlist.Songs.Contains(song))
                {
                    playlist.Songs.Add(song);
                    String AddMessage = "Song titled "+song.Title+ " added to Playlist "+ playlist.Name;
                    ViewBag.Message = AddMessage ;
                }
                else
                {
                    playlist.Songs.Remove(song);
                    String RemoveMessage = "Song titled " + song.Title + " removed from Playlist " + playlist.Name;
                    ViewBag.Message = RemoveMessage;
                }
                
                db.SaveChanges();
            }
            
            return View(viewModel);
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
            Song song = db.Songs.Include(i => i.Album)
                .Include(i => i.Author)
                .Where(i => i.Id==id)
                .Single();
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName"); //bylo Id zamiast AuthorId
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name");
            PopulateAssignedPlaylistData(song);
            if(song == null)
            {
                return HttpNotFound();
            }

            return View(song);
        }

        private void PopulateAssignedPlaylistData(Song song)
        {
            var viewModel = new Playlist();
            var playlists = db.Playlists;
            
                /*
            var allPlaylists = db.Playlists;
            var songPlaylists = new HashSet<int>(song.Playlist.Select(c => c.Id));
            //var viewModel = new List<SongIndexData>();
            foreach (var playlist in allPlaylists)
            {
                viewModel.Add(new SongIndexData
                {
                    PlaylistId = playlist.Id,
                    Name = playlist.Name,
                    Assigned = songPlaylists.Contains(playlist.Id)
                });
            }
            ViewBag.Courses = viewModel; */
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
