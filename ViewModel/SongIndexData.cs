using MusicPlayer.DataAccessLayer;
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
        public Song Song { get; set; }
        public List<Author> Authors { get {
                List<Author> list = new List<Author>();
                MusicPlayerDBContext mp = new MusicPlayerDBContext();
                list = mp.Authors.ToList();

                mp.Dispose();
                return list;
            }
            }
    }
}
