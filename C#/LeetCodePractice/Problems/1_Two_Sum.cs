using LeetCodePractice.Common;

namespace LeetCodePractice.Problems
{
    // Two sum question: Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    public class TwoSumProblem : IProblem
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numIndices = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (numIndices.ContainsKey(complement))
                {
                    return new int[] { numIndices[complement], i };
                }

                if (!numIndices.ContainsKey(nums[i]))
                {
                    numIndices[nums[i]] = i;
                }
            }

            throw new ArgumentException("No two sum solution");
        }

        public void Run()
        {
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            int[] result = TwoSum(nums, target);

            Console.WriteLine($"Indexes: [{result[0]}, {result[1]}]");
        }
    }
}
