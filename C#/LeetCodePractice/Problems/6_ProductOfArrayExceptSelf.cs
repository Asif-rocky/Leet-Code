using LeetCodePractice.Common;

namespace LeetCodePractice.Problems
{
    public class ProductOfArrayExceptSelfProblem : IProblem
    {
        // Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
        // You must write an algorithm that runs in O(n) time and without using the division operation. 
        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] answer = new int[n];

            // Calculate left products
            answer[0] = 1;
            for (int i = 1; i < n; i++)
            {
                answer[i] = answer[i - 1] * nums[i - 1];
            }

            // Calculate right products and multiply with left products
            int rightProduct = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                answer[i] *= rightProduct;
                rightProduct *= nums[i];
            }

            return answer;
        }

        public void Run()
        {
            int[] nums = { 1, 2, 3, 4 };

            var result = ProductExceptSelf(nums);

            Console.WriteLine("Product of Array Except Self:");
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }
    }
}