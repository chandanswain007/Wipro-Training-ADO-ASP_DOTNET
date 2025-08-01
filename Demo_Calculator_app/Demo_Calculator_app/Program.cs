using System;
namespace Demo_Calculator_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            Console.WriteLine("Welcome to the Calculator App!");
            Console.Write("Enter the first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select an operation: +, -, *, /");
            string operation = Console.ReadLine();

            try
            {
                switch (operation)
                {
                    case "+":
                        Console.WriteLine($"Result: {calculator.Add(num1, num2)}");
                        break;
                    case "-":
                        Console.WriteLine($"Result: {calculator.Subtract(num1, num2)}");
                        break;
                    case "*":
                        Console.WriteLine($"Result: {calculator.Multiply(num1, num2)}");
                        break;
                    case "/":
                        Console.WriteLine($"Result: {calculator.Divide(num1, num2)}");
                        break;
                    default:
                        Console.WriteLine("Invalid operation selected.");
                        break;
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public double Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return (double)a / b;
        }
    }
}