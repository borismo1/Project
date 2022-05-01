namespace FronEnd.Model
{
    public class ServiceResponce<T>
    {

        public T Data { get; set; } = default(T);

        public bool Success { get; set; } = false;

        public string Message { get; set; } = string.Empty;
    }
}
