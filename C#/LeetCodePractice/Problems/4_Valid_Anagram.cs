using LeetCodePractice.Common;

namespace LeetCodePractice.Problems
{
    // Given two strings s and t, return true if t is an anagram of s, and false otherwise.
    public class ValidAnagramProblem : IProblem
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            var charCount = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                charCount[s[i] - 'a']++;
                charCount[t[i] - 'a']--;
            }

            foreach (var count in charCount)
            {
                if (count != 0)
                    return false;
            }

            return true;
        }

        public void Run()
        {
            string s = "anagram";
            string t = "nagaram";

            bool result = IsAnagram(s, t);

            Console.WriteLine($"Is Anagram: {result}");
        }
    }
}