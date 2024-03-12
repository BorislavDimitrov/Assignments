namespace DebbugingAndExceptionHandling.Helpers
{
    public static class StringOperations
    {
        public static string ReverseString(string stringToReverse)
        {
            if (string.IsNullOrEmpty(stringToReverse))
            {
                throw new ArgumentNullException(nameof(stringToReverse), "Input string cannot be null or empty.");
            }

            char[] charArray = stringToReverse.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int CountLetterOccurences(string text, char letterToLookFor)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text), "Input text cannot be null or empty.");
            }

            if (char.IsLetter(letterToLookFor) == false)
            {
                throw new ArgumentException(nameof(letterToLookFor), "The letter we are looking for gotta be A-z, it cannot be a number, punctuation mark or special symbol.");
            }

            int count = 0;

            foreach (char c in text)
            {
                if (c == letterToLookFor)
                {
                    count++;
                }
            }
            return count;
        }

        public static string GetSubstring(string text, int startIndex, int endIndex)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text), "Text cannot be null or empty.");
            }

            if (startIndex < 0 || startIndex >= text.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index is out of bounds.");
            }

            if (endIndex < 0 || endIndex >= text.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex), "End index is out of bounds.");
            }

            if (startIndex > endIndex)
            {
                throw new ArgumentException("Start index cannot be greater than end index.");
            }

            return text.Substring(startIndex, endIndex - startIndex + 1);
        }
    }
}

