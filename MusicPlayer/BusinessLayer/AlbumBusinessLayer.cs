using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MusicPlayer.Models
{
    public class AlbumBusinessLayer
    {
        public List<Album> GetAlbums()
        {
            MusicPlayerContext db = new MusicPlayerContext();
            return (db.Albums.ToList());
        }

        public Album GetAlbumDetails(int? id)
        {
            MusicPlayerContext db = new MusicPlayerContext();
            Album album = db.Albums.Find(id);
            return (album);
        }
        
        public void SaveAlbum(Album album)
        {
            MusicPlayerContext db = new MusicPlayerContext();
            db.Albums.Add(album);
            db.SaveChanges();
            //return ();
        }

        public Album GetAlbum(int? id)
        {
            MusicPlayerContext db = new MusicPlayerContext();
            Album album = db.Albums.Find(id);
            return (album);
        }

        public void EditAlbum(Album album)
        {
            MusicPlayerContext db = new MusicPlayerContext();
            db.Entry(album).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteAlbum(Album album)
        {
            MusicPlayerContext db = new MusicPlayerContext();
            db.Albums.Remove(album);
            db.SaveChanges();
        }
        



    }
}