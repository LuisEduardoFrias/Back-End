using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Linq;

namespace ArsAffiliate.Service.RequestHeaderMatchMadiaType
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class RequestHeaderMatchMadiaType : Attribute, IActionConstraint
    {
        private readonly string _requestHeaderToMath;
        private readonly string[] _mediaTypes;

        public RequestHeaderMatchMadiaType(string requestHeaderToMath, string[] mediaTypes)
        {
            _requestHeaderToMath = requestHeaderToMath;
            _mediaTypes = mediaTypes;
        }

        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var requestHeaders = context.RouteContext.HttpContext.Request.Headers;

            if (!requestHeaders.ContainsKey(_requestHeaderToMath))
                return false;

            var headerValues = requestHeaders[_requestHeaderToMath].ToString().Split(',').ToList();
            
            foreach (var header in headerValues)
            {
                foreach(var mediatype in _mediaTypes)
                {
                    if (string.Equals(mediatype, header, StringComparison.OrdinalIgnoreCase))
                        return true;
                }
            }

            return false;
        }
    }
}
