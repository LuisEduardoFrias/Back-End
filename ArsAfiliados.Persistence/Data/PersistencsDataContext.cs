using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//
using ArsAfiliados.Domain.Entitys;
//

namespace ArsAfiliados.Persistence.Data
{
    public class PersistencsDataContext : IdentityDbContext
    {

        #region properties

        public DbSet<Affiliate> Affiliates { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<ArsAfiliados.Domain.Entitys.Service> Services { get; set; }
        public DbSet<MedicalBill> MedicalBills { get; set; }

        #endregion


        public PersistencsDataContext() : base()
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-9BPNFM1\SQLEXPRESS; database=ArsAfiliados; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
