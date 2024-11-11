namespace CalculatorApp
{
    public class Calculator
    {
        public int Add(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0;

            // Generate an array of delimiters
            var delimiters = new[] {',', '\n'};

            // Replace \n with \\n to avoid backslash escaping in split
            value = value.Replace("\\n", "\n");

            // Check for custom delimiter format: //{delimiter}\n{numbers}
            if (value.StartsWith("//") && value.Length > 4 && value[3] == '\n')
            {
                // Extract custom delimiter and add to delimiters array
                delimiters = [value[2], ',', '\n']; 
            }

            // First, split the input `value` by commas
            // Then, attempt to parse each entry as an integer, defaulting to 0 for any invalid and empty values.
            // Finally, convert the sequence into an array and return it as `numbers`.
            var numbers = value.Split(delimiters, StringSplitOptions.None)
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