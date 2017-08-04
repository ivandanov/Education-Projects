namespace Teleimot.DataServices
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Teleimot.Data;
    using Teleimot.Models;

    public class RealEstatesDataService : IRealEstatesDataService
    {
        private ITeleimotData data;

        public RealEstatesDataService(ITeleimotData data)
        {
            this.data = data;
        }

        public IEnumerable<RealEstate> GetRealEstates(int skip, int take)
        {
            return this.data.RealEstates.All()
                .OrderByDescending(r => r.CreatedOn)
                .Skip(skip * take)
                .Take(take)
                .ToList();
        }

        public RealEstate GetRealEstateDetails(int id)
        {
            try
            {
                var estate = this.data.RealEstates.GetById(id);
                return estate;
            }
            catch
            {
                // no entities with this id
                return null;
            }
        }


        public RealEstate CreateRealEstate(string userId, string title, string description, string address,
            string contact, int constructionYear, int? sellingPrice, int? rentingPrice, int type)
        {
            var newRealEstate = new RealEstate()
            {
                UserId = userId,
                Title = title,
                Description = description,
                Address = address,
                Contact = contact,
                ConstructionYear = constructionYear,
                SellingPrice = sellingPrice,
                RentingPrice = rentingPrice,
                CreatedOn = DateTime.Now,
                Type = (RealEstateType)Enum.Parse(typeof(RealEstateType), type.ToString())
            };

            this.data.RealEstates.Add(newRealEstate);
            this.data.SaveChanges();

            return newRealEstate;
        }
    }
}
