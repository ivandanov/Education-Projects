namespace Teleimot.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }
    }
}
