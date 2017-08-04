namespace Teleimot.DataServices
{
    using System.Collections.Generic;
    using Teleimot.Models;

    public interface IRealEstatesDataService
    {
        IEnumerable<RealEstate> GetRealEstates(int skip, int take);

        RealEstate GetRealEstateDetails(int id);

        RealEstate CreateRealEstate(
            string userId,
            string title, 
            string description, 
            string address, 
            string contact,
            int constructionYear, 
            int? sellingPrice, 
            int? rentingPrice, 
            int type);
    }
}
