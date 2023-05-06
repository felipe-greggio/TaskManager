using System.Net;

namespace task_manager.Response
{
    public interface IResponseResult
    {

        public bool Success { get; }
        public string? Message { get; }
        public HttpStatusCode StatusCode { get; }
        public object? Data { get; }
    }
}
