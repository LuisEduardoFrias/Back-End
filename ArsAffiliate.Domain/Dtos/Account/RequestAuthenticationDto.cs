using System;

namespace ArsAffiliate.Domain.Dtos
{
    public class RequestAuthenticationDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
