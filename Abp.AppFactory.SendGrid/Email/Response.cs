using Abp.AppFactory.Interfaces;
using SendGrid;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Abp.AppFactory
{
    public class SendGridResponse : ISendGridResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public HttpContent Body { get; set; }
        public HttpResponseHeaders Headers { get; set; }
        public Dictionary<string, dynamic> DeserializedResponseBody { get; set; }
        public Dictionary<string, string> DeserializedResponseHeaders { get; set; }

        public SendGridResponse(Response response)
        {
            StatusCode = response.StatusCode;
            Body = response.Body;
            Headers = response.Headers;
            DeserializedResponseBody = response.DeserializeResponseBody(response.Body);
            DeserializedResponseHeaders = response.DeserializeResponseHeaders(response.Headers);
        }
    }
}