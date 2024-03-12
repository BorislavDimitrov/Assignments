using DebbugingAndExceptionHandling.CustomExceptions;
using System.Text.RegularExpressions;

namespace DebbugingAndExceptionHandling.Validators
{
    public static class UserInputValidator
    {
        public static void IsPhoneNumValid(string number)
        {
             string pattern = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException(nameof(number), "Input number cannot be null or empty.");
            }

            var isMatch = Regex.IsMatch(number, pattern);

            if (isMatch == false)
            {
                throw new PhoneNumberNotValidException();
            }
        }

        public static void IsEmailValid(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email), "Input email cannot be null or empty.");
            }

            int atIndex = email.IndexOf('@');
            int dotIndex = email.LastIndexOf('.');

            if (atIndex < 1 || dotIndex < atIndex + 2 || dotIndex == email.Length - 1)
            {
                throw new EmailIsNotValidException();
            }

            string domainPart = email.Substring(atIndex + 1);
            if (!domainPart.Contains('.'))
            {
                throw new EmailIsNotValidException();
            }
        }

        public static void IsNameValid(string name)
        {
            string pattern = @"^[a-zA-Z]+(?:\s+[a-zA-Z]+)*$";

            var isValid = Regex.IsMatch(name, pattern);

            if (isValid == false)
            {
                throw new NameNotValidException();
            }
        }
    }
}
