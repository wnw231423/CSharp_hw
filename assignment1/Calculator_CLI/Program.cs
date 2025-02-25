using System;

namespace Calculator_CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A simple calculator. Support + - * / between integers.");
            while (true)
            {
                Console.WriteLine("Enter 'q' to quit, others to continue...");
                if (Console.ReadLine() == "q")
                {
                    return;
                }
                Console.WriteLine("Please enter an integer: ");
                int a1 = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Please enter another integer: ");
                int a2 = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Please enter an operator: ");
                string s = Console.ReadLine();
                int valid = 1;
                int res = 0;
                switch (s)
                {
                    case "+":
                        res = a1 + a2;
                        break;
                    case "-":
                        res = a1 - a2;
                        break;
                    case "*":
                        res = a1 * a2;
                        break;
                    case "/":
                        res = a1 / a2;
                        break;
                    default:
                        Console.WriteLine("Invalid operator");
                        valid = 0;
                        break;
                }
                if (valid == 1)
                {
                    Console.WriteLine($"The result is {res}");
                }
            }
        }
    }
}
