using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.Exception
{
    public class ApiResponse<T>
    {

        public T? Data { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }

        private ApiResponse(bool success, string message, T? data, IEnumerable<string>? errors)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors;
        }

        public static ApiResponse<T> SuccessResponse(T data,string message) => new ApiResponse<T>(true,message,data,null);

        public static ApiResponse<T> FailResponse(string message, IEnumerable<string> error) => new ApiResponse<T>(false,message,default,error);
    }
}
