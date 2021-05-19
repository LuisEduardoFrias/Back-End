using ArsAffiliate.Domain.Entitys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ArsAffiliate.Persistence.Configurations
{
    public class RoleConfigurations
    {
        public RoleConfigurations(EntityTypeBuilder<Role> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

            entityBuilder.HasData(
                new Role
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                });

            entityBuilder.HasMany(e => e.UserRoles).WithOne(e => e.Role).HasForeignKey(e => e.RoleId).IsRequired();
        }
    }
}
