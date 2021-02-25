using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_2
{
    public static class NumberConverter
    {
        public static void ConvertNumberToBinary()
        {
            const string format = "{0,-32}{1}";
            Console.Clear();

            Console.Write("Enter number to convert to binary(unsigned int):\n=> ");

            uint number;
            while (!uint.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Invalid input. Try Again\n=> ");
            }

            Console.WriteLine();
            Console.WriteLine(format, "Number:", $"{number}");
            Console.WriteLine(format, "Binary representation:", $"{ConvertUintToBinary(number)}");
            Console.WriteLine(format, "Representation using .NET:", $"{Convert.ToString(number, 2).PadLeft(32, '0')}");
        }

        private static string ConvertUintToBinary(uint number)
        {
            if (number == 0)
            {
                return "0";
            }

            //Цикл для получения отдельных битов
            string reversedBinary = string.Empty;
            for (uint num = number; num > 1; num /= 2)
            {
                reversedBinary += num % 2;
            }

            //Добавляем единицу в конце
            reversedBinary += 1;

            //Разворачиваем порядок битов
            StringBuilder output = new StringBuilder();
            for (int i = reversedBinary.Length - 1; i >= 0; i--)
            {
                output.Append(reversedBinary[i]);
            }
            //Возвращаем полученую строку с недостающими нулями
            return output.ToString().PadLeft(32, '0');
        }
    }
}
