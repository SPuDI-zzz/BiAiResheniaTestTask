namespace Services.Palindrome
{
    public class PalindromeService : IPalindromeService
    {
        public bool IsPalindrome(string word)
        {
            word = word.ToLower();

            for (int index = 0; index < word.Length / 2; index++)
            {
                if (word[index] != word[word.Length - index - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
