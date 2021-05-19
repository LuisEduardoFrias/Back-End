using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ArsAffiliate.Domain.Entitys
{
    public class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
