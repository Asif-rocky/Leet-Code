using LeetCodePractice.Common;

namespace LeetCodePractice.Problems
{
  public class VerifyingAnAlienDictionaryProblem : IProblem
  {
    // Given a sequence of words written in an alien language, and the order of the alphabet,
    // return true if and only if the given words are sorted lexicographically in this alien language.
    // Example: Input: words = ["hello","leetcode"], order = "hlabcdefgijkmnopqrstuvwxyz"
    // Output: true Explanation: As 'h' comes before 'l' in this language, then the sequence is sorted.
    public bool IsAlienSorted(string[] words, string order)
    {
      // 1. Create a mapping of each character to its index in the alien order.
      Dictionary<char, int> charOrder = new Dictionary<char, int>();
      for (int i = 0; i < order.Length; i++)
      {
        charOrder[order[i]] = i;
      }

      // 2. Compare each pair of adjacent words.
      for (int i = 0; i < words.Length - 1; i++)
      {
        if (!InCorrectOrder(words[i], words[i + 1], charOrder))
        {
          return false;
        }
      }

      return true;
    }

    private bool InCorrectOrder(string word1, string word2, Dictionary<char, int> charOrder)
    {
      int minLength = Math.Min(word1.Length, word2.Length);

      for (int i = 0; i < minLength; i++)
      {
        if (word1[i] != word2[i])
        {
          return charOrder[word1[i]] < charOrder[word2[i]];
        }
      }

      return word1.Length <= word2.Length;
    }

    public void Run()
    {
      string[] words = { "hello", "leetcode" };
      string order = "hlabcdefgijkmnopqrstuvwxyz";

      bool result = IsAlienSorted(words, order);
      Console.WriteLine($"Are the words sorted in the alien dictionary? {result}");
    }
  }
}