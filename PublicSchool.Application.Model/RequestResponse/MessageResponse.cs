using System.Net;

namespace PublicSchool.Application.Model.RequestResponse
{
    public class MessageResponse<TResponse>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public TResponse Data { get; set; }
        public int Count { get; set; }
    }
}