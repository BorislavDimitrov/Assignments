namespace DebbugingAndExceptionHandling.Helpers
{
    public static class MathOperations
    {
        public static int Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Factorial is defined only for non-negative integers.");
            }

            int result = 1;

            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        public static double Divide(int dividend, int divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return (double)dividend / divisor;
        }

        public static int[] FibonacciSequence(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Number of terms must be greater than zero.");
            }

            int[] sequence = new int[n];

            sequence[0] = 0;

            if (n > 1)
            {
                sequence[1] = 1;
            }

            for (int i = 2; i < n; i++)
            {
                checked
                {
                    sequence[i] = sequence[i - 1] + sequence[i - 2]; 
                }
            }

            return sequence;
        }
    }
}
