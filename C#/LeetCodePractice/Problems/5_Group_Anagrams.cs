using LeetCodePractice.Common;

namespace LeetCodePractice.Problems
{
    public class GroupAnagramsProblem : IProblem
    {
        // Given an array of strings strs, group the anagrams together. You can return the answer in any order.
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var anagramMap = new Dictionary<string, List<string>>();

            foreach (var str in strs)
            {
                var charArray = str.ToCharArray();
                Array.Sort(charArray);
                var sortedStr = new string(charArray);

                if (!anagramMap.ContainsKey(sortedStr))
                {
                    anagramMap[sortedStr] = new List<string>();
                }
                anagramMap[sortedStr].Add(str);
            }

            return new List<IList<string>>(anagramMap.Values);
        }

        public void Run()
        {
            string[] strs = { "eat", "tea", "tan", "ate", "nat", "bat" };

            var result = GroupAnagrams(strs);

            Console.WriteLine("Grouped Anagrams:");
            foreach (var group in result)
            {
                Console.WriteLine($"[{string.Join(", ", group)}]");
            }
        }
    }
}