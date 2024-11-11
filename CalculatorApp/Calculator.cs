using CalculatorApp.Helpers;

namespace CalculatorApp
{
    public class Calculator
    {
        private readonly Parser _parser;

        public Calculator(Parser parser)
        {
            _parser = parser;
        }

        public int Add(string input, 
            bool denyNegativeNumbers = true, 
            int upperBound = 1000, 
            string? alternateDelimiter = null)
        {
            // First extract valid numbers for calculation
            var numbers = _parser.ExtractNumbersFromInput(input, denyNegativeNumbers, upperBound, alternateDelimiter);
            int result = numbers.Length > 0  ? numbers.Sum() : 0;
            // display the formula 
            var formula = string.Join(" + ", numbers);
            Console.WriteLine($"{formula} = {result}");
            return result;
        }
    }
}
