using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Foundation.Models
{
    public class GoodsDonation
    {
        [Key]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int ItemAmount { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public GoodsDonation()
        {

        }
    }
}
