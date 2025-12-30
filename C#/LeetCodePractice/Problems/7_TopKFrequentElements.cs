using LeetCodePractice.Common;

namespace LeetCodePractice.Problems
{
  public class TopKFrequentElementsProblem : IProblem
  {
    // Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
    // Example: Input: nums = [1,1,1,2,2,3], k = 2 Output: [1,2]
    public int[] TopKFrequent(int[] nums, int k)
    {
      var frequencyMap = new Dictionary<int, int>();
      foreach (var num in nums)
      {
        if (frequencyMap.ContainsKey(num))
          frequencyMap[num]++;
        else
          frequencyMap[num] = 1;
      }

      var sortedByFrequency = frequencyMap.OrderByDescending(pair => pair.Value).Take(k).Select(pair => pair.Key).ToArray();
      return sortedByFrequency;
    }

    // Alternative using PriorityQueue (min-heap) to maintain top-k by frequency.
    // Requires .NET 6+ (PriorityQueue<TElement, TPriority>).
    public int[] TopKFrequentHeap(int[] nums, int k)
    {
      // Step 1: Count the frequency of each element using a dictionary (hash map)
      var counts = new Dictionary<int, int>();
      foreach (int num in nums)
      {
        counts[num] = counts.GetValueOrDefault(num, 0) + 1;
      }

      // Step 2: Use a min-heap (PriorityQueue) to keep track of the k most frequent elements
      // The priority is the frequency (int), and the element is the number (int).
      // We use a min-heap so that the element with the smallest frequency is always at the top.
      var pq = new PriorityQueue<int, int>();

      foreach (var entry in counts)
      {
        int num = entry.Key;
        int frequency = entry.Value;

        // Add the number and its frequency to the priority queue
        pq.Enqueue(num, frequency);

        // If the heap size exceeds k, remove the element with the minimum frequency (at the top)
        if (pq.Count > k)
        {
          pq.Dequeue();
        }
      }

      // Step 3: Extract the elements from the priority queue
      // The remaining elements in the heap are the k most frequent.
      int[] result = new int[k];
      for (int i = 0; i < k; i++)
      {
        result[i] = pq.Dequeue();
      }

      return result;
    }

    public void Run()
    {
      int[] nums = { 1, 1, 1, 2, 2, 3 };
      int k = 2;

      var result = TopKFrequent(nums, k);

      Console.WriteLine("Top K Frequent Elements:");
      Console.WriteLine($"[{string.Join(", ", result)}]");

      var resultHeap = TopKFrequentHeap(nums, k);
      Console.WriteLine("Top K Frequent Elements (PriorityQueue):");
      Console.WriteLine($"[{string.Join(", ", resultHeap)}]");
    }
  }
}