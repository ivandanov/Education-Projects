namespace Teleimot.WepApi.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RateInput
    {
        public string UserId { get; set; }

        [Range(minimum: 1, maximum: 5)]
        public byte Value { get; set; }
    }
}