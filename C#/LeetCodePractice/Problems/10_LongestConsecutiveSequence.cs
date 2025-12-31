using LeetCodePractice.Common;

namespace LeetCodePractice.Problems
{
  public class LongestConsecutiveSequenceProblem : IProblem
  {
    // Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
    // Example: Input: nums = [100,4,200,1,3,2] Output: 4 Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
    public static int LongestConsecutive(int[] nums)
    {
      if (nums.Length == 0) return 0;

      HashSet<int> numSet = new HashSet<int>(nums);
      int longestStreak = 0;

      foreach (int num in numSet)
      {
        // Only start counting if 'num' is the start of a sequence
        if (!numSet.Contains(num - 1))
        {
          int currentNum = num;
          int currentStreak = 1;

          // Count the length of the sequence starting from 'num'
          while (numSet.Contains(currentNum + 1))
          {
            currentNum += 1;
            currentStreak += 1;
          }

          longestStreak = Math.Max(longestStreak, currentStreak);
        }
      }

      return longestStreak;
    }

    public void Run()
    {
      int[] nums = { 100, 4, 200, 1, 3, 2 };
      int result = LongestConsecutive(nums);
      Console.WriteLine($"Length of the longest consecutive sequence: {result}");
    }
  }
}