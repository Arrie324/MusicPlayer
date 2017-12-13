using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MusicPlayer.ViewModel
{
    public class SongIndexData
    {
        public IEnumerable<Song> Songs { get; set; }
        public IEnumerable<Playlist> Playlists { get; set; }
    }
}
