namespace WebFormsExam.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Like
    {
        public int Id { get; set; }

        public string VoterId { get; set; }

        public virtual ApplicationUser Voter { get; set; }

        public int PlaylistId { get; set; }

        public virtual Playlist Playlist { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
