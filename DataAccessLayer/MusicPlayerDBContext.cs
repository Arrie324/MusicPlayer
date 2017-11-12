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
        public DbSet<User> User { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<Album> Album { get; set; }
    }
}
