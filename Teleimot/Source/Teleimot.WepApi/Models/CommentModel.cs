namespace Teleimot.WepApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Teleimot.Models;
    using Teleimot.WepApi.Infrastructure.Mapping;

    public class CommentModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Content { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration config)
        {
            config.CreateMap<Comment, CommentModel>()
                .ForMember(m => m.UserName, op => op.MapFrom(g => g.User.UserName));
        }
    }
}