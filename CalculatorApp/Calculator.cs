namespace CalculatorApp
{
    public class Calculator
    {
        public int Add(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0;

            // First, split the input `value` by commas
            // Then, attempt to parse each entry as an integer, defaulting to 0 for any invalid and empty values.
            // Finally, convert the sequence into an array and return it as `numbers`.
            var numbers = value.Split(",")
                            .Select(n => int.TryParse(n, out int number) ? number : 0)
                            .ToArray();
                            
            if (numbers.Length > 2)
                throw new ArgumentException("Only up to two numbers are allowed.");

            // Based on Stretch goals #1, here we generate the formula for numbers addition.
            var formula = string.Join(" + ", numbers.Select(n => n < 0 ? $"({n})" : n.ToString()));

            int result = numbers.Sum();

            Console.WriteLine($"{formula} = {result}");

            return result;
        }
    }
}