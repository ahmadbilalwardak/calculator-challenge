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
        
        public int Subtract(string input, 
            bool denyNegativeNumbers = true, 
            int upperBound = 1000, 
            string? alternateDelimiter = null)
        {
            // First extract valid numbers for calculation
            var numbers = _parser.ExtractNumbersFromInput(input, denyNegativeNumbers, upperBound, alternateDelimiter);
            int result = numbers.Length > 0  ? numbers.Aggregate((acc, next) => acc - next) : 0;
            // display the formula 
            var formula = string.Join(" - ", numbers);
            Console.WriteLine($"{formula} = {result}");
            return result;
        }
        
        public int Multiply(string input, 
            bool denyNegativeNumbers = true, 
            int upperBound = 1000, 
            string? alternateDelimiter = null)
        {
            // First extract valid numbers for calculation
            var numbers = _parser.ExtractNumbersFromInput(input, denyNegativeNumbers, upperBound, alternateDelimiter);
            int result = numbers.Length > 0 ? numbers.Aggregate(1, (acc, next) => acc * next) : 0;
            // display the formula 
            var formula = string.Join(" * ", numbers);
            Console.WriteLine($"{formula} = {result}");
            return result;
        }
        
        public double Divide(string input, 
            bool denyNegativeNumbers = true, 
            int upperBound = 1000, 
            string? alternateDelimiter = null)
        {
            // First extract valid numbers for calculation
            var numbers = _parser.ExtractNumbersFromInput(input, denyNegativeNumbers, upperBound, alternateDelimiter);
            double result = numbers.Length > 0 ? numbers.Skip(1).Aggregate((double)numbers[0], (acc, next) => acc / (double)next) : 0;
            // display the formula 
            var formula = string.Join(" / ", numbers);
            // With round off
            Console.WriteLine($"{formula} = {result.ToString("F2")}");
            // Without roundoff
            Console.WriteLine($"{formula} = {Math.Floor(result * 100) / 100:0.00}");
            return result;
        }
    }
}
