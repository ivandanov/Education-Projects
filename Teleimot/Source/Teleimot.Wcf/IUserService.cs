namespace Teleimot.Wcf
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    [ServiceContract]
    public interface IUserService
    {
        [WebGet(UriTemplate = "/users/top.svc/")]
        [OperationContract]
        IEnumerable<UserWcfModel> TopTenUserByRating();
    }    
}
