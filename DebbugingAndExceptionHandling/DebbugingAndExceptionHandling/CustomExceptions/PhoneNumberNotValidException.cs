namespace DebbugingAndExceptionHandling.CustomExceptions
{
    public class PhoneNumberNotValidException : Exception
    {

        public PhoneNumberNotValidException(string message = "The phone number provided is not valid.")
        : base(message)
        {

        }

        public PhoneNumberNotValidException(string message, Exception inner)
        : base(message, inner)
        {

        }
    }
}
