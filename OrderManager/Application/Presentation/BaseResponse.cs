using Newtonsoft.Json;

namespace Application.Presentation
{
    public class BaseResponse<T> where T : class
    {
        public T Data { get; init; }
        public string Message { get; init; }
        public int StatusCode { get; init; }
        public bool Succeeded { get; init; }

        public BaseResponse(string message, T data, int statusCode, bool succeeded)
        {
            Data = data;
            Succeeded = succeeded;
            Message = message;
            StatusCode = statusCode;
        }

        public BaseResponse()
        {
        }

        public static BaseResponse<T> Success(string message, T data, int statusCode = 200)
        {
            return new BaseResponse<T>
            {
                Data = data,
                Succeeded = true,
                Message = message,
                StatusCode = 200
            };
        }

        public static BaseResponse<T> Failure(string message, T data, int statusCode)
        {
            return new BaseResponse<T>
            {
                Data = data,
                Succeeded = false,
                Message = message,
                StatusCode = statusCode
            };
        }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
