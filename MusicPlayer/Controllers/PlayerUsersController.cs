using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicPlayer.Models;

namespace MusicPlayer.Controllers
{
    public class PlayerUsersController : Controller
    {
        private MusicPlayerContext db = new MusicPlayerContext();

        // GET: PlayerUsers
        public ActionResult Index()
        {
            return View(db.PlayerUsers.ToList());
        }

        // GET: PlayerUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerUser playerUser = db.PlayerUsers.Find(id);
            if (playerUser == null)
            {
                return HttpNotFound();
            }
            return View(playerUser);
        }

        // GET: PlayerUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PlayerUser playerUser)
        {
            if (ModelState.IsValid)
            {
                db.PlayerUsers.Add(playerUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playerUser);
        }

        // GET: PlayerUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerUser playerUser = db.PlayerUsers.Find(id);
            if (playerUser == null)
            {
                return HttpNotFound();
            }
            return View(playerUser);
        }

        // POST: PlayerUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] PlayerUser playerUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playerUser);
        }

        // GET: PlayerUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerUser playerUser = db.PlayerUsers.Find(id);
            if (playerUser == null)
            {
                return HttpNotFound();
            }
            return View(playerUser);
        }

        // POST: PlayerUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerUser playerUser = db.PlayerUsers.Find(id);
            db.PlayerUsers.Remove(playerUser);
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
