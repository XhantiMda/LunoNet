namespace LunoNet.Network
{
    public class ApiResponse<T> where T : class
    {
        public ApiResponse(StatusCode statusCode, T data = null)
        {
            Data = data;
            StatusCode = statusCode;
        }

        public T Data { get; private set; }
        public StatusCode StatusCode { get; private set; }
    }
}
