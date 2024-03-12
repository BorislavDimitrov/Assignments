#define CUSTOM

using DebbugingAndExceptionHandling;
using DebbugingAndExceptionHandling.CustomExceptions;
using DebbugingAndExceptionHandling.Helpers;
using DebbugingAndExceptionHandling.Validators;

try
{

#if(CUSTOM)

    PerformMathOperations();
    Console.WriteLine("Math operations performed" + new string('-', 100));

    PerformStringOperations();
    Console.WriteLine("String operations performed" + new string('-', 100));

#endif

    CreateUser("InvalidName1", "invalid@email", "invalid phone number");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

void PerformMathOperations()
{
    try
    {
        var factorialResult = MathOperations.Factorial(5);
        Console.WriteLine($"Factorial of 5 is: {factorialResult}");

        var divisionResult = MathOperations.Divide(100, 2);
        Console.WriteLine($"The division of 100 and 0 is: {divisionResult}");

        var fibonacciSequenceResult = MathOperations.FibonacciSequence(10);
        Console.WriteLine("fibonacci sequence up to 10 is : " + string.Join(", ", fibonacciSequenceResult));
    }
    catch (Exception ex)
    {
        throw;
    }
}

void PerformStringOperations()
{
    try
    {
        var reverseStringResult = StringOperations.ReverseString("Some string");
        Console.WriteLine($"The reversed string is: {reverseStringResult}");

        var letterOccurencesResult = StringOperations.CountLetterOccurences("Some random string", 'o');
        Console.WriteLine($"The occurences of the letter 'o' in the text 'Some random string' are: {letterOccurencesResult}");

        var substringResult = StringOperations.GetSubstring("Random string to get substring of.", 0, 5);
        Console.WriteLine($"The substring is: {substringResult}");
    }
    catch (Exception ex)
    {
        throw ex;
    }
}

void CreateUser(string name, string email, string phoneNumber)
{
    try
    {
        UserInputValidator.IsNameValid(name);
        UserInputValidator.IsEmailValid(email);
        UserInputValidator.IsPhoneNumValid(phoneNumber);

        var newUser = new User(name, email, phoneNumber);
        Console.WriteLine($"A new user with the following information has been created: Name: {name}, Email: {email}, Phone number: {phoneNumber}");
    }
    catch (NameNotValidException ex)
    {
        Console.WriteLine("There was some problem with the given user name. Please provide a valid name next time.");
    }
    catch (EmailIsNotValidException ex)
    {
        Console.WriteLine("There was some problem with the given user email. Please provide a valid email next time.");
    }
    catch (PhoneNumberNotValidException ex)
    {
        Console.WriteLine("There was some problem with the given user phone number. Please provide a valid phone number next time.");
    }
    catch (Exception ex)
    {
        throw;
    }
    finally
    {
        Console.WriteLine("Thank you for creating a new user. If the user is not created successfully try again by providing valid information.");
    }
}
