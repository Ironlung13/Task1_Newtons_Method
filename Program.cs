﻿using System;

namespace Task1_Newton_s_Method
{
    class Program
    {
        static void Main(string[] args)
        {
        EntryPoint:
            Console.WriteLine("Welcome, User!");
            Console.Write("Enter number for calculation (floating point number):\n=> ");

            //Ввод число, корень которого будем искать
            double number;
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Invalid input. Try again\n=> ");
            }
            
            //Ввод степень корня
            uint power;
            Console.Write("Enter power of root value(positive non-zero integer):\n=> ");

        EnteringPowerOfRoot:
            while (!uint.TryParse(Console.ReadLine(), out power) ||
                    power == 0)
            {
                Console.Write("Invalid input. Try again\n=> ");
            }
            
            //Проверка на возможность извлечения корня
            if (number < 0 && power % 2 == 0)
            {
                Console.WriteLine($"{number} is less than zero, so power of root can't be even.");
                goto EnteringPowerOfRoot;
            }

            //Ввод точности вычесления корня
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

            //Блок вывода
            Console.WriteLine($"\nNumber=> {number}");
            Console.WriteLine($"Power of root=> {power}");
            //Расчет корня
            //Первый способ - итерационный метод Ньютона
            //Второй способ - Math.Pow
            double result = CustomFormulae.FindNthRootOfNumber(number, power, precision);
            double resultPow = Math.Pow(number, 1d / power);
            //Вывод финальной информации
            Console.WriteLine($"Approximate Root: {result}");
            Console.WriteLine($"Root calculated via Math.Pow=>{resultPow}");
            Console.WriteLine($"Difference between results is {Math.Abs(result - resultPow)}");

            //Вопрос пользователю об остановке программы или перезапуске
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
