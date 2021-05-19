using ArsAffiliate.Domain.Entitys;
using ArsAffiliate.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArsAffiliate.Persistence.Data
{
    public class PersistencsDataContext : IdentityDbContext<User, Role, string>
    {

        #region properties

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
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

            ModelConfig(builder);

        }

        public void ModelConfig(ModelBuilder modelBuilder)
        {
            new RoleConfigurations(modelBuilder.Entity<Role>());
            new UserConfigurations(modelBuilder.Entity<User>());
        }
    }
}
