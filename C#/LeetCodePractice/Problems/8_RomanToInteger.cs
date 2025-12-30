using LeetCodePractice.Common;

namespace LeetCodePractice.Problems
{
  public class RomanToIntegerProblem : IProblem
  {
    // Given a roman numeral, convert it to an integer.
    // Example: Input: s = "LVIII" Output: 58 Explanation: L = 50, V= 5, III = 3.
    public static int RomanToInt(string s)
    {
      // 1. Map Roman symbols to integer values using a Dictionary.
      Dictionary<char, int> romanMap = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

      int total = 0;

      // 2. Iterate through the string, stopping before the last character.
      for (int i = 0; i < s.Length - 1; i++)
      {
        int currentVal = romanMap[s[i]];
        int nextVal = romanMap[s[i + 1]];

        // 3. Apply the subtraction rule logic:
        // If the current symbol's value is less than the next symbol's value, subtract it.
        // (e.g., in "IV", 'I' (1) < 'V' (5), so we treat 'I' as -1 in the running total).
        if (currentVal < nextVal)
        {
          total -= currentVal;
        }
        // Otherwise, add the current value as usual.
        else
        {
          total += currentVal;
        }
      }

      // 4. Add the value of the last character, which is always added and never subtracted.
      total += romanMap[s[s.Length - 1]];

      return total;

    }

    // 2nd Solution
    public int RomanToIntSecondSolution(string s)
    {
      var romanMap = new Dictionary<string, int>()
        {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000},
            {"IV", 4},
            {"IX", 9},
            {"XL", 40},
            {"XC", 90},
            {"CD", 400},
            {"CM", 900},
        };

      int total = 0;
      int i = 0;

      while (i < s.Length)
      {
        // Check 2-character symbol first
        if (i < s.Length - 1)
        {
          string twoSymbol = s.Substring(i, 2);
          if (romanMap.ContainsKey(twoSymbol))
          {
            total += romanMap[twoSymbol];
            i += 2;
            continue;
          }
        }

        // Otherwise process 1-character symbol
        string oneSymbol = s[i].ToString();
        total += romanMap[oneSymbol];
        i += 1;
      }

      return total;
    }

    public void Run()
    {
      string romanNumeral = "MCMXCIV"; // Example input
      int result = RomanToInt(romanNumeral);
      Console.WriteLine($"The integer value of the Roman numeral {romanNumeral} is {result}.");

      string romanNumeral2 = "LVIII"; // Example input for second solution
      int result2 = RomanToIntSecondSolution(romanNumeral2);
      Console.WriteLine($"The integer value of the Roman numeral {romanNumeral2} is {result2}.");
    }

  }
}