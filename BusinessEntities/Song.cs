using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class Song
    {
        public Song()
        {
            this.Playlist = new HashSet<Playlist>();
        }

        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        //[ForeignKey("Id")]
        public Author Author { get; set; }
        public int? AuthorId { get; set; }
        //[ForeignKey("Id")]
        public Album Album { get; set; }
        public int AlbumId { get; set; }
        public Genre Genre { get; set; }
        [ForeignKey("Id")]
        public virtual ICollection<Playlist> Playlist { get; set; }
    }
}
