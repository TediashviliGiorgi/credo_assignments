using System.Transactions;

namespace calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                string header = "Hello";
                Console.WriteLine = (header);
                //number validations---------------

                Console.WriteLine("Enter first number: ");
                var firstNumber = Console.ReadLine();
                bool isFirstNumberNumeric = double.TryParse(firstNumber, out _);

                Console.WriteLine("Enter second number: ");
                var secondNumber = Console.ReadLine();
                bool isSecondNumberNumeric = double.TryParse(secondNumber, out _);

                if (isFirstNumberNumeric && isSecondNumberNumeric)
                {
                //-----------------------------------
                    Console.WriteLine("enter math operation: (+ - * /): ");
                    string? operation = Console.ReadLine();

                    double answer;
                    if (Convert.ToDouble(secondNumber) == 0)
                    {
                        Console.WriteLine("can't divide by zero");
                    }
                    else if (operation == "+")
                    {
                        answer = Convert.ToDouble(firstNumber) + Convert.ToDouble(secondNumber);
                        Console.WriteLine($"{firstNumber} + {secondNumber} = {answer}");
                    }
                    else if (operation == "-")
                    {
                        answer = Convert.ToDouble(firstNumber) - Convert.ToDouble(secondNumber);
                        Console.WriteLine($"{firstNumber} - {secondNumber} = {answer}");
                    }
                    else if (operation == "*")
                    {
                        answer = Convert.ToDouble(firstNumber) * Convert.ToDouble(secondNumber);
                        Console.WriteLine($"{firstNumber} * {secondNumber} = {answer}");
                    }
                    else if (operation == "/")
                    {
                        answer = Convert.ToDouble(firstNumber) / Convert.ToDouble(secondNumber);
                        Console.WriteLine($"{firstNumber} / {secondNumber} = {answer}");
                    }
                    else
                    {
                        Console.WriteLine("please enter correct operation");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Both variable must be a number");

                }
            }
            while (true);
        }
    }
}