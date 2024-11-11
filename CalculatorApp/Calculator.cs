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

            // Check for custom delimiter of any length using format: //[{delimiter}]\n{numbers}
            if (value.StartsWith("//") && value.Contains("\n"))
            {
                string pattern = @"^//(\[(.+?)\]|(.))\n";
                var match = Regex.Match(value, pattern);

                if (match.Success)
                {
                    // The pattern is divided into groups group 2 is for the multi-character delimiter 
                    // and group 3 is for single character delimiter
                    var customDelimiter = match.Groups[2].Success ? match.Groups[2].Value : match.Groups[3].Value;
                    delimiters.Add(customDelimiter);
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