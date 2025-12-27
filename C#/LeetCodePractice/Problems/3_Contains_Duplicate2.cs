using LeetCodePractice.Common;

namespace LeetCodePractice.Problems
{
    // Contains duplicate II question: Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.
    public class ContainsDuplicateProblemTwo : IProblem
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> numIndices = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (numIndices.ContainsKey(nums[i]))
                {
                    if (i - numIndices[nums[i]] <= k)
                    {
                        return true;
                    }
                }
                numIndices[nums[i]] = i;
            }

            return false;
        }

        public void Run()
        {
            int[] nums = { 1, 2, 3, 1 };
            int k = 3;

            bool result = ContainsNearbyDuplicate(nums, k);

            Console.WriteLine($"Contains Nearby Duplicate: {result}");
        }
    }
}