using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class PlayerUser
    {
        public PlayerUser(String Name)
        {
            this.Name = Name;
        }
        public PlayerUser(){}

        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
