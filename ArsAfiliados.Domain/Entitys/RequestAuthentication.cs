using System;

namespace ArsAfiliados.Domain.Entitys
{
    public class RequestAuthentication
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string UserName { get; set; }
        public string Error { get; set; }
    }
}
