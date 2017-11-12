using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Song> AlbumSongs { get; set; }
    }
}
