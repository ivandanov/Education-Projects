namespace Teleimot.WepApi.Models
{
    using AutoMapper;
    using Teleimot.Models;
    using Teleimot.WepApi.Infrastructure.Mapping;

    public class RealEstateModel : IMapFrom<RealEstate>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? SellingPrice { get; set; }

        public int? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<RealEstate, RealEstateModel>()
                .ForMember(m => m.CanBeSold, op => 
                    op.MapFrom(g => g.SellingPrice == null ? false : true))
                .ForMember(m => m.CanBeRented, op =>
                    op.MapFrom(g => g.RentingPrice == null ? false : true));
        }
    }
}