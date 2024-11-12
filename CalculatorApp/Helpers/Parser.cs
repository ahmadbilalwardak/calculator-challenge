using System.Text.RegularExpressions;

namespace CalculatorApp.Helpers
{
    public class Parser
    {
        public int[] ExtractNumbersFromInput(string input, bool denyNegativeNumbers, int upperBound, string? alternateDelimiter = null)
        {
            if (string.IsNullOrWhiteSpace(input))
                return [];

            var delimiters = new List<string> { ",", alternateDelimiter ?? "\n" };

            // Replace \n with \\n to avoid backslash escaping in split
            input = alternateDelimiter == null ? input.Replace("\\n", "\n") : input;

            var match = Regex.Match(input, @"^//(?:\[(.+?)\]|(.))\n");
            if (match.Success)
            {
                delimiters = ExtractCustomDelimiters(input, delimiters, match);
            }

            var numbers = ParseNumbers(input, delimiters, upperBound);
            
            if (denyNegativeNumbers)
            {
                CheckForNegativeNumbers(numbers);
            }

            return numbers;
        }

        private static List<string> ExtractCustomDelimiters(string input, List<string> delimiters, Match match)
        {
            // Multi-character delimiters in square brackets
            if (match.Groups[1].Success) 
            {
                // Extract all multi-character delimiters within square brackets
                delimiters.AddRange(Regex.Matches(input, @"\[(.+?)\]")
                                         .Cast<Match>()
                                         .Select(m => m.Groups[1].Value));
            }
            else if (match.Groups[2].Success) // Single character delimiter
            {
                delimiters.Add(match.Groups[2].Value);
            }

            return delimiters;
        }

        private static int[] ParseNumbers(string input, List<string> delimiters, int upperBound)
        {
            // First, split the input `value` by delimiters 
            // Then, attempt to parse each entry as an integer, defaulting to 0 for any invalid and empty values.
            // Finally, convert the sequence into an array and return it as `numbers`.
            string splitPattern = string.Join("|", delimiters.Select(Regex.Escape));
            
            return Regex.Split(input, splitPattern)
                        .Select(n => int.TryParse(n, out int number) && number <= upperBound ? number : 0)
                        .ToArray();
        }

        private static void CheckForNegativeNumbers(int[] numbers)
        {
            var negatives = numbers.Where(n => n < 0).ToList();
            if (negatives.Count != 0)
            {
                throw new ArgumentException($"Negative numbers are not allowed: {string.Join(", ", negatives)}");
            }
        }
    }
}