using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Disaster_Alleviation_Foundation.Models;

namespace Disaster_Alleviation_Foundation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Disaster_Alleviation_Foundation.Models.Disaster>? Disaster { get; set; }
        public DbSet<Disaster_Alleviation_Foundation.Models.GoodsDonation>? GoodsDonation { get; set; }
        public DbSet<Disaster_Alleviation_Foundation.Models.MonetaryDonation>? MonetaryDonation { get; set; }
        public DbSet<Disaster_Alleviation_Foundation.Models.AllocateMoney>? AllocateMoney { get; set; }
    }
}