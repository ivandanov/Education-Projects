using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebFormsExam.Models
{
    public class Category
    {
        private ICollection<Playlist> playlists;

        public Category()
        {
            this.playlists = new HashSet<Playlist>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Playlist> Playlists
        {
            get { return this.playlists; }
            set { this.playlists = value; }
        }
    }
}
