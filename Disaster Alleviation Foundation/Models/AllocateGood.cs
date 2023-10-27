using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Foundation.Models
{
    public class AllocateGood
    {
        [Key]
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public int ItemAmount { get; set; }
        public string Category { get; set; }
        public string DisasterType { get; set; }
        public string DisasterId { get; set; }

        public AllocateGood()
        {
            
        }
    }
}
