namespace Teleimot.WepApi.Models
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using Teleimot.Models;
    using Teleimot.WepApi.Infrastructure.Mapping;

    public class RealEstatePrivateDetails : IMapFrom<RealEstate>, IHaveCustomMappings
    {
        public string Address { get; set; }

        public ICollection<CommentModel> Comments { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ConstructionYear { get; set; }

        public string RealEstateType { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public int? SellingPrice { get; set; }

        public int? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<RealEstate, RealEstatePrivateDetails>()
                .ForMember(m => m.RealEstateType, op =>
                    op.MapFrom(g => g.Type.ToString()))
                .ForMember(m => m.CanBeSold, op =>
                    op.MapFrom(g => g.SellingPrice == null ? false : true))
                .ForMember(m => m.CanBeRented, op =>
                    op.MapFrom(g => g.RentingPrice == null ? false : true));
        }
    }
}