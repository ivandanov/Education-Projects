namespace WebFormsExam.Models
{
    public class Video
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int PlaylistId { get; set; }

        public virtual Playlist Playlist { get; set; }
    }
}
