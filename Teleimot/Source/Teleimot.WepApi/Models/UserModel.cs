namespace Teleimot.WepApi.Models
{
    using System.Linq;
    using System.Data.Entity;
    using AutoMapper;
    using Teleimot.Models;
    using Teleimot.WepApi.Infrastructure.Mapping;

    public class UserModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public int RealEstates { get; set; }

        public int Comments { get; set; }

        public double Rating { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<User, UserModel>()
                .ForMember(m => m.Comments, op => op.MapFrom(g =>
                    g.Comments.Count))
                .ForMember(m => m.Rating, op => op.MapFrom(g => 
                    g.Ratings.Count == 0 ? 0 : g.Ratings.Average(r => r.Value)))
                .ForMember(m => m.RealEstates, op => op.MapFrom(g => g.RealEstates.Count));
        }
    }
}