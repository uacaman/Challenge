namespace Core
{
    /// <summary>
    /// Result object to encapsulate any return value with optional error information.
    /// 
    /// For a rest request, the result json is: {  "value": T, "error": "string" }
    /// 
    /// </summary>
    /// <typeparam name="T">The type of the value in the response.</typeparam>
    public struct Result<T>
    {
        private readonly T _value;

        /// <summary>
        /// Gets the value of the response.
        /// </summary>
        public T Value => _value;

        /// <summary>
        /// Gets or sets the error message, if any.
        /// </summary>
        public string Error { get; set; } = string.Empty;

        // Private constructor for creating successful responses
        private Result(T value)
        {
            _value = value;
            Error = string.Empty;
        }

        // Private constructor for creating error responses
        private Result(string error)
        {
            _value = default!;
            Error = error;
        }

        /// <summary>
        /// Implicitly converts a value to a Response<T> with no error.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Result<T>(T value)
        {
            return new Result<T>(value);
        }

        /// <summary>
        /// Implicitly converts an Error to a Response<T> with the error message.
        /// </summary>
        /// <param name="error">The Error object to convert.</param>
        public static implicit operator Result<T>(Error error)
        {
            
            return new Result<T>(error.Message);
        }

        /// <summary>
        /// Implicitly converts a Response<T> to a boolean indicating success or failure.
        /// </summary>
        /// <param name="result">The response to convert.</param>
        public static implicit operator bool(Result<T> result)
        {
            return string.IsNullOrEmpty(result.Error);
        }
    }
}
