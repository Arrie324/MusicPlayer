using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class PlaylistSongs
    {
        DbSet<Playlist> Playlist { get; set; }
        DbSet<Song> Song { get; set; }
    }
}
