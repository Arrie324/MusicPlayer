using MusicPlayer.Models;
using MusicPlayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Controllers
{
    public class SongBusinessLayer
    {
        public void GetSongIndexData(int? id, int? playlistId)
        {
            private MusicPlayerContext db = new MusicPlayerContext();

        var viewModel = new SongIndexData();
            viewModel.Songs = db.Songs.Include(d => d.Author).Include(d => d.Album);

            if (id != null)
            {
                //string query = "SELECT * FROM Playlists";
                //ViewBag.SongId = id.Value;
                viewModel.Playlists = db.Playlists.SqlQuery("SELECT * FROM Playlists");
            }

            if (playlistId != null)
            {

                ViewBag.PlaylistId = playlistId.Value;
                var song = db.Songs.Find(id);
                var playlist = db.Playlists.SqlQuery("SELECT * FROM Playlists WHERE Id = {0}", playlistId).Single();
                if (!playlist.Songs.Contains(song))
                {
                    playlist.Songs.Add(song);
                    String AddMessage = "Song titled " + song.Title + " added to Playlist " + playlist.Name;
                    ViewBag.Message = AddMessage;
                }
                else
                {
                    playlist.Songs.Remove(song);
                    String RemoveMessage = "Song titled " + song.Title + " removed from Playlist " + playlist.Name;
                    ViewBag.Message = RemoveMessage;
                }

                db.SaveChanges();
            }
        }

    }
}
