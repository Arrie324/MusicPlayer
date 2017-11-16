using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class PlaylistSongs
    {
        [Key]
        int ID { get; set; }
        DbSet<Playlist> Playlist { get; set; }
        DbSet<Song> Song { get; set; }
    }
}
