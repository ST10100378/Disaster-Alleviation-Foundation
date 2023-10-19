using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Foundation.Models
{
    public class Disaster
    {
        [Key]
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Discription { get; set; }
        public string AidType { get; set; }

        public Disaster()
        {

        }
    }
}
