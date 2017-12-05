using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MusicPlayer.Models  //było w DataAccesLayer
{
    public class MusicPlayerDBContext : DbContext
    {
        public DbSet<PlayerUser> PlayerUsers { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<PlaylistSongs> PlaylistSongs { get; set; }
        public DbSet<Author> Authors { get; set; }
        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Playlist>()
                .HasMany(c => c.Songs).WithMany(i => i.Playlist)
                .Map(t => t.MapLeftKey("Id")
                .MapRightKey("Id")
                .ToTable("PlaylistSongs"));
            
                
        }
        */
    }
}
