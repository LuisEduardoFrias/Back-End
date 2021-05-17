using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ArsAffiliate.Domain.Entitys;

namespace ArsAffiliate.Persistence.Data
{
    public class PersistencsDataContext : IdentityDbContext
    {

        #region properties

        public DbSet<Affiliate> Affiliates { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<Domain.Entitys.Service> Services { get; set; }
        public DbSet<MedicalBill> MedicalBills { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<ServiceDoctor> ServiceDoctors { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }

        #endregion


        public PersistencsDataContext(DbContextOptions<PersistencsDataContext> options) : base(options)
        {
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server=DESKTOP-9BPNFM1\SQLEXPRESS; database=ArsAfiliados; Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
