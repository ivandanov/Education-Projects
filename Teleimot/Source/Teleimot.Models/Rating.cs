namespace Teleimot.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        public int Id { get; set; }

        [Range(minimum: 1, maximum: 5)]
        public byte Value { get; set; }

        public string RatedUserId { get; set; }

        public virtual User RatedUser { get; set; }
    }
}
