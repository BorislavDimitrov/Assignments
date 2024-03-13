
using DelegatesAndLINQ;

List<int> numbers = new List<int> {-10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//With Delegates

List<int> delegateEvenNumbers = Filter(numbers, FilterEven);

List<int> delegateOddNumbers = Filter(numbers, FilterOdd);

List<int> delegatePositiveNumbers = Filter(numbers, FilterPositive);

List<int> delegateNegativeNumbers = Filter(numbers, FilterNegative);

List<int> delegatePerfectSquareNumbers = Filter(numbers, FilterPerfectSquare);

List<int> delegatePrimeNumbers = Filter(numbers, FilterPrime);

Console.WriteLine(string.Join(", ", delegateEvenNumbers));
Console.WriteLine(string.Join(", ", delegateOddNumbers));
Console.WriteLine(string.Join(", ", delegatePositiveNumbers));
Console.WriteLine(string.Join(", ", delegateNegativeNumbers));
Console.WriteLine(string.Join(", ", delegatePerfectSquareNumbers));
Console.WriteLine(string.Join(", ", delegatePrimeNumbers));

bool FilterEven(int x)
{
    return x % 2 == 0;
}

bool FilterOdd(int x)
{
    return x % 2 != 0;
}

bool FilterPositive (int x)
{
    return x >= 0;
}

bool FilterNegative(int x)
{
    return x < 0;
}

bool FilterPerfectSquare(int x)
{
    if (x <= 0)
    {
        return false;
    }

    double root = Math.Sqrt(x);
    return root == Math.Floor(root);
}

bool FilterPrime(int x)
{
    if (x <= 1)
    {
        return false;
    }
    int root = (int)Math.Sqrt(x);
    for (int i = 2; i <= root; i++)
    {
        if (x % i == 0)
        {
            return false;
        }
    }
    return true;
}

static List<T> Filter<T>(List<T> collection, Func<T, bool>  filterDelegate)
{
    List<T> result = new List<T>();

    foreach (T item in collection)
    {
        if (filterDelegate(item))
        {
            result.Add(item);
        }
    }

    return result;
}

//With Anonymous functions and Lambda expressions / statements.
//I will do a little of both so i dont repeat same code again and again

List<int> anonymousEvenNumbers = Filter(numbers, delegate (int x)
{
    return x % 2 == 0;
});

List<int> anonymousOddNumbers = Filter(numbers, delegate (int x)
{
    return x % 2 != 0;
});

List<int> anonymousPositiveNumbers = Filter(numbers, delegate(int x)
{
    return x >= 0;
});

List<int> lambdaNegativeNumbers = Filter(numbers, x => x < 0);

List<int> lambdaPerfectSquareNumbers = Filter(numbers, x =>
{
    if (x <= 0)
    {
        return false;
    }

    double root = Math.Sqrt(x);
    return root == Math.Floor(root);
});

List<int> lambdaPrimeNumbers = Filter(numbers, x =>
{
    if (x <= 1)
    {
        return false;
    }
    int root = (int)Math.Sqrt(x);
    for (int i = 2; i <= root; i++)
    {
        if (x % i == 0)
        {
            return false;
        }
    }
    return true;
});

Console.WriteLine(new string('*', 150));

Console.WriteLine(string.Join(", ", anonymousEvenNumbers));
Console.WriteLine(string.Join(", ", anonymousOddNumbers));
Console.WriteLine(string.Join(", ", anonymousPositiveNumbers));
Console.WriteLine(string.Join(", ", lambdaNegativeNumbers));
Console.WriteLine(string.Join(", ", lambdaPerfectSquareNumbers));
Console.WriteLine(string.Join(", ", lambdaPrimeNumbers));

//With Extension method 
var extensionMethodEvenNumbers = numbers.GetEvenNumbers();

var extensionMethodOddNumbers = numbers.GetOddNumbers();

var extensionMethodPositiveNumbers = numbers.GetPositiveNumbers();

var extensionMethodNegativeNumbers = numbers.GetNegativeNumbers();

var extensionMethodPerfectSquareNumbers = numbers.GetPerfectSquareNumbers();

var extensionMethodPrimeNumbers = numbers.GetPrimeNumbers();

Console.WriteLine(new string('*', 150));

Console.WriteLine(string.Join(", ", extensionMethodEvenNumbers));
Console.WriteLine(string.Join(", ", extensionMethodOddNumbers));
Console.WriteLine(string.Join(", ", extensionMethodPositiveNumbers));
Console.WriteLine(string.Join(", ", extensionMethodNegativeNumbers));
Console.WriteLine(string.Join(", ", extensionMethodPerfectSquareNumbers));
Console.WriteLine(string.Join(", ", extensionMethodPrimeNumbers));

//With LINQ 

var linqEvenNumbers = numbers.Where(x => x % 2 == 0).ToList();

var linqOddNumbers = numbers.Where(x => x % 2 != 0).ToList();

var linqPositiveNumbers = numbers.Where(x => x >= 0).ToList();

var linqNegativeNumbers = numbers.Where(x => x < 0).ToList();

var linqPerfectSquareNumbers = numbers.Where( x => x >0 && Math.Sqrt(x) == Math.Floor(Math.Sqrt(x))).ToList();

var linqPrimeNumbers = numbers.Where(x => x > 1 &&
        Enumerable.Range(2, (int)Math.Sqrt(x) - 1)
        .All(divisor => x % divisor != 0)).ToList();

Console.WriteLine(new string('*', 150));

Console.WriteLine(string.Join(", ", linqEvenNumbers));
Console.WriteLine(string.Join(", ", linqOddNumbers));
Console.WriteLine(string.Join(", ", linqPositiveNumbers));
Console.WriteLine(string.Join(", ", linqNegativeNumbers));
Console.WriteLine(string.Join(", ", linqPerfectSquareNumbers));
Console.WriteLine(string.Join(", ", linqPrimeNumbers));