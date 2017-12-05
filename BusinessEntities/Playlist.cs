using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class Playlist
    {
        public Playlist()
        {
            this.Songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Id")]
        public virtual ICollection<Song> Songs { get; set; }
        public PlayerUser user { get; set; }

        
    }
}
