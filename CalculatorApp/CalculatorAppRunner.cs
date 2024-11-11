// CalculatorAppRunner.cs
namespace CalculatorApp
{
    public class CalculatorAppRunner
    {
        private readonly Calculator _calculator;

        public CalculatorAppRunner(Calculator calculator)
        {
            _calculator = calculator;
        }

        public void Run()
        {
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("  Welcome to the Calculator App! - Enter input or type 'exit' to quit.");
            Console.WriteLine("------------------------------------------------------------------------");

            // Get additional options from the user
            Console.Write("Alternate delimiter (leave blank for default): ");
            string? alternateDelimiter = Console.ReadLine() ?? null;

            Console.Write("Deny negative numbers? (yes/no): ");
            bool denyNegativeNumbers = Console.ReadLine()?.Trim().ToLower() == "yes";

            Console.Write("Upper bound for valid numbers (default 1000): ");
            if (!int.TryParse(Console.ReadLine(), out int upperBound))
            {
                upperBound = 1000;
            }

            // bool denyNegativeNumbers = true;
            // int upperBound = 1000;
            // string? alternateDelimiter = null;
            
            while (true)
            {
                Console.Write("Input (or type 'exit' to quit): ");
                string input = Console.ReadLine() ?? string.Empty;

                if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                    break;

                try
                {
                    _calculator.Add(input, denyNegativeNumbers, upperBound, alternateDelimiter);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine("Thank you for using the Calculator app!");
            Console.WriteLine("Regards, Ahmad Bilal");
        }
    }
}
