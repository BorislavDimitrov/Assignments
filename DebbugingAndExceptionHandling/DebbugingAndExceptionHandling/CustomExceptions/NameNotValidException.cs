namespace DebbugingAndExceptionHandling.CustomExceptions
{
    public class NameNotValidException : Exception
    {
        public NameNotValidException(string message = "The name provided is not valid.")
        : base(message)
        {

        }

        public NameNotValidException(string message, Exception inner)
        : base(message, inner)
        {

        }
    }
}
