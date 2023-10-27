using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Foundation.Models
{
    public class AllocateMoney
    {
        [Key]
        public string UserName { get; set; }
        public double Amount { get; set; }
        public DateTime DonationDate { get; set; }
        public string DisaterType { get; set; }
        public string DisasterId { get; set; }

        public AllocateMoney()
        {
            
        }
    }
}
