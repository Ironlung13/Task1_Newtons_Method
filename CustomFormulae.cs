using System;
using System.Collections.Generic;
using System.Text;

namespace Task1_Newton_s_Method
{
    public static class CustomFormulae
    {
        public static double FindNthRootOfNumber(double number, uint power, double accuracy)
        {
            if ((number < 0 && power % 2 == 0) ||
                power == 0 ||
                double.IsNaN(number) ||
                double.IsNegativeInfinity(number) ||
                double.IsPositiveInfinity(number))
            {
                throw new ArgumentException("number and/or degree is invalid.");
            }

            if (accuracy < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(accuracy));
            }

            if (power == 1)
            {
                return number;
            }
            else
            {
                double result;
                double resultPrevious = number; //first assumption
                while (true)
                {
                    result = 1d / power * ((resultPrevious * (power - 1)) + (number / Math.Pow(resultPrevious, power - 1)));
                    if (Math.Abs(result - resultPrevious) < accuracy)
                    {
                        return result;
                    }
                    else
                    {
                        resultPrevious = result;
                    }
                }
            }
        }
    }
}
