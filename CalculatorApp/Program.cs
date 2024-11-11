namespace CalculatorApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("------------------------------------------------------------------------");
        Console.WriteLine("  Welcome to the Calculator App! - Enter input or type 'exit' to quit.");
        Console.WriteLine("------------------------------------------------------------------------");

        var calculator = new Calculator();

        while (true)
        {
            Console.Write("Input: ");
            string input = Console.ReadLine() ?? string.Empty;

            if (input.ToLower() == "exit")
                break;

            try
            {
                int result = calculator.Add(input);
                Console.WriteLine($"Addition Result: {result}");
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