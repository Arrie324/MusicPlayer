﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class PlaylistSongs
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        DbSet<Playlist> Playlist { get; set; }
        [ForeignKey("Id")]
        DbSet<Song> Song { get; set; }
    }
}
