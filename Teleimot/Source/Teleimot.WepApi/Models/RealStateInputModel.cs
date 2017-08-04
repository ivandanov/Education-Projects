namespace Teleimot.WepApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RealStateInputModel
    {
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

        [Range(0.0, Double.MaxValue)]
        public int ConstructionYear { get; set; }

        public int SellingPrice { get; set; }

        public int RentingPrice { get; set; }

        public byte Type { get; set; }
    }
}