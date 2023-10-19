using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Foundation.Models
{
    public class MonetaryDonation
    {
        [Key]
        public string UserName { get; set; }
        public DateTime DonationDate { get; set; }
        public Double Amount { get; set; }

        public MonetaryDonation()
        {

        }
    }
}
