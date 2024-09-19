namespace Core
{
    /// <summary>
    /// Represents an error that occurs in the business logic of the application.
    /// Contains a message that can be displayed to the user.
    /// This class can be implicitly converted to a result type when needed.
    /// </summary>
    public class Error
    {
        public string Message { get; set; }

        public Error(string message)
        {
            Message = message;
        }
    }
}
