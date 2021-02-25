using System;

namespace Task1_Newton_s_Method
{
    class Program
    {
        static void Main(string[] args)
        {
        EntryPoint:
            Console.WriteLine("Welcome, User!");
            Console.Write("Enter number in question (floating point number):\n=> ");


            double number;
            while (!double.TryParse(Console.ReadLine(), out number) ||
                    number > double.MaxValue ||
                    number < double.MinValue)
            {
                Console.Write("Invalid input. Try again\n=> ");
            }


            uint power;
            Console.Write("Enter power of root value(positive non-zero integer):\n=> ");

        EnteringPowerOfRoot:
            while (!uint.TryParse(Console.ReadLine(), out power) ||
                    power == 0)
            {
                Console.Write("Invalid input. Try again\n=> ");
            }

            if (number < 0 && power % 2 == 0)
            {
                Console.WriteLine($"{number} is less than zero, so power of root can't be even.");
                goto EnteringPowerOfRoot;
            }

            double precision;
            Console.WriteLine("Enter precision value (the lower, the better).");
            Console.Write("For epsilon enter \"epsilon\"\n=> ");

        EnteringPrecision:
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "epsilon":
                    precision = double.Epsilon;
                    break;
                default:
                    if (!double.TryParse(answer, out precision))
                    {
                        Console.Write("Invalid input. Try again\n=> ");
                        goto EnteringPrecision;
                    }
                    else
                        break;
            }

            Console.WriteLine($"\nNumber=> {number}");
            Console.WriteLine($"Power of root=> {power}");
            double result = CustomFormulae.FindNthRootOfNumber(number, power, precision);
            Console.WriteLine($"Approximate Root: {result}");
            Console.WriteLine($"Root calculated via Math.Pow=>{Math.Pow(number,1d / power)}");

            Console.WriteLine("To quit, enter \"q\"");
            Console.WriteLine("To restart program, enter anything else.");
            switch(Console.ReadLine())
            {
                case "q":
                    return;
                default:
                    Console.Clear();
                    goto EntryPoint;
            }
        }
    }
}
