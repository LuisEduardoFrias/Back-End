using System;
using System.Net;

namespace ArsAffiliate.Application
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
        public String MensajeError { get; set; }
    }
}
