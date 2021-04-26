using System;

namespace ArsAfiliados.Domain.Dtos
{
    public class RequestAuthenticationDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string Error { get; set; }
    }
}
