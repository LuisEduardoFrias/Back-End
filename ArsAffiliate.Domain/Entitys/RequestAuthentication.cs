using System;

namespace ArsAffiliate.Domain.Entitys
{
    public class RequestAuthentication
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string Error { get; set; }
    }
}
