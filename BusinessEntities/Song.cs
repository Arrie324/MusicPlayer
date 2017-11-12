using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Album Album { get; set; }
        public Genre Genre { get; set; }
        public virtual ICollection<Playlist> Playlist { get; set; }
    }
}
