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
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        //[ForeignKey("Id")]
        public Author Author { get; set; }
        public int? AuthorId { get; set; }
        public Album Album { get; set; }
        public Genre Genre { get; set; }
        public virtual ICollection<Playlist> Playlist { get; set; }
    }
}
