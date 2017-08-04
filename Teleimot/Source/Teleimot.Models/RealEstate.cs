namespace Teleimot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RealEstate
    {
        private ICollection<Comment> comments;

        public RealEstate()
        {
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        public RealEstateType Type { get; set; }

        public int? SellingPrice { get; set; }

        public int? RentingPrice { get; set; }

        public DateTime CreatedOn { get; set; }

        [Range(0.0, Double.MaxValue)]
        public int ConstructionYear { get; set; }

        public string UserId { get; set; }

        public virtual User user { get; set; }

        public virtual ICollection<Comment> Comments 
        {
            get { return this.comments; }
            set { this.comments = value; }
        }        
    }
}
