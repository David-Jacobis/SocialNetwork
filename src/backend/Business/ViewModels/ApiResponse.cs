using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class ApiResponse<T> where T : class
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
        

        public static ApiResponse<T> NotFoundResponse(string entity, int idEntity, string controller, string genero)
        {
            switch (genero)
            {
                case "M":
                    return ErrorResponse($"The entity {entity} {idEntity} was not found.",
                           new { });

                case "F":
                    return ErrorResponse($"Entity {entity} {idEntity} not found.",
                        new { });
            };

            return null;
        }

        public static ApiResponse<T> ErrorResponse(string message, object error)
        {
            return new ApiResponse<T>
            {
                Message = message,
                Error = error,
                Data = null
            };
        }

        public static ApiResponse<T> SuccessResponse(string message, T data)
        {
            return new ApiResponse<T>
            {
                Message = message,
                Data = data,
                Error = null
            };
        }

        public ApiResponse() { }
    }
}
