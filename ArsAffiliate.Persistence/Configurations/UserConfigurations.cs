using ArsAffiliate.Domain.Entitys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArsAffiliate.Persistence.Configurations
{
    public class UserConfigurations
    {
        public UserConfigurations(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.FirstName).IsRequired().HasMaxLength(25);
            entityBuilder.Property(x => x.LastName).IsRequired().HasMaxLength(25);

            entityBuilder.HasMany(e => e.UserRoles).WithOne(e => e.user).HasForeignKey(e => e.UserId).IsRequired();
        }
    }
}
