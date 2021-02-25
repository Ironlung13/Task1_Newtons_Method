using System;

namespace Task_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
        EntryPoint:
            Console.WriteLine("Welcome, User!");
            Console.WriteLine("Choose method to run:");
            Console.WriteLine("1: Find Nth root of number.");
            Console.Write("2: Convert number to binary.\n=> ");
        MethodChoice:
            switch (Console.ReadLine())
            {
                case "1":
                    CustomFormulae.FindNthRootOfNumber();
                    break;
                case "2":
                    NumberConverter.ConvertNumberToBinary();
                    break;
                default:
                    Console.Write("Invalid Input. Try Again\n=> ");
                    goto MethodChoice;
            }

            //Вопрос пользователю об остановке программы или перезапуске
            Console.WriteLine("\n\nTo quit, enter \"q\"");
            Console.WriteLine("To restart program, enter anything else.");
            switch (Console.ReadLine())
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
