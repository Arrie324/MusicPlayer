using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public User user { get; set; }

    }
}
