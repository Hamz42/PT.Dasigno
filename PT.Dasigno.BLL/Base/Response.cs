namespace PT.Dasigno.BLL.Base
{
    public class Response<T>
    {
        public T Data { get; private set; } = default!;
        public string ErrorMessage { get; private set; } = default!;
        public bool Success => ErrorMessage == null;

        public static Response<T> FromError(string errorMessage)
        {
            return new Response<T> { ErrorMessage = errorMessage };
        }

        public static Response<T> FromData(T data)
        {
            return new Response<T> { Data = data };
        }
    }
}
