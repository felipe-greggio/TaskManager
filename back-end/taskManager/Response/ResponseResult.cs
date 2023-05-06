using Microsoft.AspNetCore.Http;
using System.Net;

namespace task_manager.Response
{
    public class ResponseResult : IResponseResult
    {
        public bool Success { get; }
        public string? Message { get; }
        public HttpStatusCode StatusCode { get; }
        public object? Data { get; }

        private ResponseResult(bool success, string? message, HttpStatusCode statusCode, object? data = null)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
            Data = data;
        }

        public static ResponseResult ReturnFail(object? data = null, string? message = null)
        {
            return new ResponseResult(false, message, HttpStatusCode.BadRequest, data);
        }

        public static ResponseResult ReturnError(string? message = null, object? data = null)
        {
            return new ResponseResult(false, message, HttpStatusCode.InternalServerError, data);
        }

        public static ResponseResult ReturnSuccess(string? message = null, object? data = null, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            return new ResponseResult(true, message, httpStatusCode, data);
        }

        public static ResponseResult ReturnNotFound(string? message = null, object? data = null, HttpStatusCode httpStatusCode = HttpStatusCode.NotFound)
        {
            return new ResponseResult(false, message, httpStatusCode, data);
        }

    }
}
