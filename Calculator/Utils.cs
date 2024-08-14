using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCodeYou
{
    public static class Utils
    {
        public static bool IsInteger(this string number, out int result)
        {
            return int.TryParse(number, out result);
        }

        public static int GetValidInteger(string promt, bool divide = false)
        {
            int number;
            bool isValid = false;
            do
            {
                Console.WriteLine($"Enter integer to {promt}");
                var input = Console.ReadLine();

                if (input.IsInteger(out number)) 
                {
                    if (divide && number.Equals(0))
                    {
                        Console.WriteLine("Invalid input. Cannot divide by zero. Try again.");
                    }
                    else 
                    {
                        isValid = true;
                    }
                }
                else
                    Console.WriteLine("The input is not a valid integer. Please try again.");

            } while (!isValid);

            return number;
        }
    }
}
