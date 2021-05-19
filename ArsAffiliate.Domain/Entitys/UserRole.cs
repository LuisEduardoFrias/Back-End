using Microsoft.AspNetCore.Identity;

namespace ArsAffiliate.Domain.Entitys
{
    public class UserRole : IdentityUserRole<string>
    {
        public Role Role { get; set; }
        public User user { get; set; }
    }
}
