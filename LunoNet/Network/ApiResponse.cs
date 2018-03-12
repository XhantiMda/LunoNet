namespace LunoNet.Network
{
    public class ApiResponse<T> where T : class
    {
        public ApiResponse(StatusCode statusCode, T data = null, string rawData = null)
        {
            Data = data;
            StatusCode = statusCode;
            RawData = rawData;
        }

        public T Data { get; private set; }
        public StatusCode StatusCode { get; private set; }
        public string RawData { get; set; }
    }
}