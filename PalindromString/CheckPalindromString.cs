namespace PalindromString
{
    public class CheckPalindromString
    {
        public static bool CheckPalindrom(string word)
        {
            bool result = false;
            if (word.Length == 0) return result;
            else if (word.Length == 1) result = true;
            else
            {
                result = Palindrom(word.ToUpper(), 0, word.Length - 1);
            }
            return result;
        }
        static bool Palindrom(string word, int start, int end)
        {
            if (start == end)
                return true;
            else if (word[start] != word[end])
                return false;
            else if (start < end + 1)
                return Palindrom(word, start + 1, end - 1);

            return true;
        }
    }
}
