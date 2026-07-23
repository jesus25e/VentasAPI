using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Shared.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; init; }
        public string Message { get; init; } = string.Empty;
        public T? Data { get; init; }
        public IEnumerable<string>? Errors { get; init; }

        public static ApiResponse<T> Ok(
            T data,
            string message = "Operación completada")
        {
            return new()
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static ApiResponse<T> Fail
            (
                string message,
                IEnumerable<string>? errors = null
                        )
        {
            return new()
            {
                Success = false,
                Message = message,
                Errors = errors
            };
        }
    }
}
