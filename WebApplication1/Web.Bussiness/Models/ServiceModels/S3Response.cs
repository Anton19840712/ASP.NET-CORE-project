using System.Net;

namespace Web.Bussiness.Models.ServiceModels
{
    public class S3Response
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
    }
}