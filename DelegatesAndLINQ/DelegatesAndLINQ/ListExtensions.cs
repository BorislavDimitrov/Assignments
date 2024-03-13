namespace DelegatesAndLINQ
{
    public static class ListExtensions
    {
        public static List<int> GetEvenNumbers(this List<int> list)
        {
            var evenNubers = new List<int>();

            foreach (var num in list)
            {
                if (num % 2 == 0)
                {
                    evenNubers.Add(num);
                }
            }

            return evenNubers;
        }

        public static List<int> GetOddNumbers(this List<int> list)
        {
            var oddNumbers = new List<int>();

            foreach (var num in list)
            {
                if (num % 2 != 0)
                {
                    oddNumbers.Add(num);
                }
            }

            return oddNumbers;
        }

        public static List<int> GetPositiveNumbers(this List<int> list)
        {
            var positiveNumbers = new List<int>();

            foreach (var num in list)
            {
                if (num >= 0)
                {
                    positiveNumbers.Add(num);
                }
            }

            return positiveNumbers;
        }

        public static List<int> GetNegativeNumbers(this List<int> list)
        {
            var negativeNumbers = new List<int>();

            foreach (var num in list)
            {
                if (num < 0)
                {
                    negativeNumbers.Add(num);
                }
            }

            return negativeNumbers;
        }

        public static List<int> GetPerfectSquareNumbers(this List<int> list)
        {
            var perfectSquareNumbers = new List<int>();

            foreach (var num in list)
            {
                if (num <= 0)
                {
                    continue;
                }

                double root = Math.Sqrt(num);

                if (root == Math.Floor(root) == true)
                {
                    perfectSquareNumbers.Add(num);
                }
            }

            return perfectSquareNumbers;
        }

        public static List<int> GetPrimeNumbers(this List<int> list)
        {
            var primeNumbers = new List<int>();

            foreach (var num in list)
            {
                if (num <= 1)
                {
                    continue;
                }

                int root = (int)Math.Sqrt(num);
                bool breakFlag = true;

                for (int i = 2; i <= root; i++)
                {
                    if (num % i == 0)
                    {
                        breakFlag = false;
                        break;
                    }
                }

                if (breakFlag == false) continue;
                
                primeNumbers.Add(num);
            }
         
            return primeNumbers;
        }
    }
}
