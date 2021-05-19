using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ArsAffiliate.Domain.Entitys
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
