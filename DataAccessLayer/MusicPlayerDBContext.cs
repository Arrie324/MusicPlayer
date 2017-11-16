using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Models;

namespace MusicPlayer.DataAccessLayer
{
    public class MusicPlayerDBContext : DbContext
    {
        public DbSet<PlayerUser> PlayerUsers { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<PlaylistSongs> Tracklist { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
