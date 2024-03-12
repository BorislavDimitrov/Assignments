namespace DebbugingAndExceptionHandling.CustomExceptions
{
    public class EmailIsNotValidException : Exception
    {

        public EmailIsNotValidException(string message = "The email provided is not valid.")
        : base(message)
        {

        }

        public EmailIsNotValidException(string message, Exception inner)
        : base(message, inner)
        {

        }
    }
}
