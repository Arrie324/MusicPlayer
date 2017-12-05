using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModel
{
    public class PlaylistIndexData
    {
        public Playlist Playlist { get; set; }
        public IEnumerable<Song> Songs { get; set; }
    }
}
