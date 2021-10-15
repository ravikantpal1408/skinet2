using System;
namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Request, You made",
                401 => "Authorize, you are not allowed",
                404 => "Resource not found",
                500 => "Internal Server Error. Due to some internal crashing we are unable to process your request",
                _ => null
            };
        }

    }
}
