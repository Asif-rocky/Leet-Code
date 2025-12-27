using LeetCodePractice.Common;

namespace LeetCodePractice.Problems
{
    // Contains duplicate question: Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct. 
    public class ContainsDuplicateProblem : IProblem
    {
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> seenNumbers = new HashSet<int>();

            foreach (int num in nums)
            {
                if (seenNumbers.Contains(num))
                {
                    return true;
                }
                seenNumbers.Add(num);
            }

            return false;
        }

        public void Run()
        {
            int[] nums = { 1, 2, 3, 1 };

            bool result = ContainsDuplicate(nums);

            Console.WriteLine($"Contains Duplicate: {result}");
        }
    }
}