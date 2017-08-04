namespace Teleimot.Wcf
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserWcfModel
    {
        double rating = 0;
        string userName = string.Empty;

        [DataMember]
        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}