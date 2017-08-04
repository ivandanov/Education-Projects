using System;
using System.Collections.Generic;
namespace WebFormsExam.Models
{
    public class Playlist
    {
        private ICollection<Video> videos;
        private ICollection<Like> rating;

        public Playlist()
        {
            this.videos = new HashSet<Video>();
            this.rating = new HashSet<Like>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Video> Videos
        {
            get
            {
                return this.videos;
            }

            set
            {
                this.videos = value;
            }
        }

        public virtual ICollection<Like> Rating
        {
            get
            {
                return this.rating;
            }

            set
            {
                this.rating = value;
            }
        }
    }
}
