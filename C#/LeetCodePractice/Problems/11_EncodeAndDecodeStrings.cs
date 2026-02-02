using System.Text;
using LeetCodePractice.Common;

namespace LeetCodePractice.Problems
{
    public class EncodeAndDecodeStringsProblem : IProblem
    {
        // Design an algorithm to encode a list of strings to a single string. The encoded string is then sent over the network and is decoded back to the original list of strings.
        // Example: Input: strs = ["Hello","World"] Output: ["Hello","World"]
        public static string Encode(IList<string> strs)
        {
            StringBuilder encoded = new StringBuilder();
            foreach (string str in strs)
            {
                encoded.Append(str.Length).Append('#').Append(str);
            }
            return encoded.ToString();
        }
        public static IList<string> Decode(string s)
        {
            List<string> decoded = new List<string>();
            int i = 0;
            while (i < s.Length)
            {
                int j = i;
                while (s[j] != '#') j++;
                int length = int.Parse(s.Substring(i, j - i));
                decoded.Add(s.Substring(j + 1, length));
                i = j + length + 1;
            }
            return decoded;
        }
        public void Run()
        {
            IList<string> strs = new List<string> { "Hello", "World" };
            string encoded = Encode(strs);
            IList<string> decoded = Decode(encoded);
            Console.WriteLine("Encoded: " + encoded);
            Console.WriteLine("Decoded: [" + string.Join(", ", decoded) + "]");
        }
    }
}