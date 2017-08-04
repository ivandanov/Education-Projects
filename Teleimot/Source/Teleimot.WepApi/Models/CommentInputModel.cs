using System.ComponentModel.DataAnnotations;
namespace Teleimot.WepApi.Models
{
    public class CommentInputModel
    {
        public int RealEstateId { get; set; }
        
        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Content { get; set; }
    }
}