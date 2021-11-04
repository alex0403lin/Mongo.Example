namespace WebAPI.Models
{
    public class ResponseResult<T>
    {
        public ResponseResult(bool success, T? data)
        {
            Success = success;
            Data = data;
        }

        public bool Success { get; set; }
        public T? Data { get; set; }
    }
}