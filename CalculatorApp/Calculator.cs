using System.Text.RegularExpressions;

namespace CalculatorApp
{
    public class Calculator
    {
        public int Add(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0;

            // Generate an array of delimiters
            var delimiters = new List<string> { ",", "\n" };

            // Replace \n with \\n to avoid backslash escaping in split
            value = value.Replace("\\n", "\n");

            // Check for custom delimiters (single character, multiple character and multiple inside square brackets)
            var match = Regex.Match(value, @"^//(?:\[(.+?)\]|(.))\n");

            if (match.Success)
            {
                // Multi-character delimiters in square brackets
                if (match.Groups[1].Success) 
                {
                    // Extract all multi-character delimiters within square brackets
                    delimiters.AddRange(Regex.Matches(value, @"\[(.+?)\]")
                                             .Cast<Match>()
                                             .Select(m => m.Groups[1].Value));
                }
                else if (match.Groups[2].Success) // Single character delimiter
                {
                    delimiters.Add(match.Groups[2].Value);
                }
            }

            // First, split the input `value` by delimiters 
            // Then, attempt to parse each entry as an integer, defaulting to 0 for any invalid and empty values.
            // Finally, convert the sequence into an array and return it as `numbers`.
            var numbers = Regex.Split(value, string.Join("|", delimiters.Select(Regex.Escape)))
                   .Select(n => int.TryParse(n, out int number) && number <= 1000 ? number : 0)
                   .ToArray();

            // Look for negative numbers and thow exception if found any
            var negatives = numbers.Where(n => n < 0).ToList();

            if (negatives.Any())
            {
                throw new ArgumentException($"Negative numbers are not allowed: {string.Join(", ", negatives)}");
            }

            // Based on Stretch goals #1, here we generate the formula for numbers addition.
            var formula = string.Join(" + ", numbers);

            int result = numbers.Sum();

            Console.WriteLine($"{formula} = {result}");

            return result;
        }
    }
}