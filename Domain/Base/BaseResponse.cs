using System.Net;

namespace Domain.Base
{
    public class BaseResponse<T> where T : class
    {
        public T Data { get; set; }
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
    }
}