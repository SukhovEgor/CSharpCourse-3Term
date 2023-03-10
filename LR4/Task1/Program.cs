/*Составить программу, которая число, заданное в
десятичной системе счисления, переведет в: а) двоичную
систему счисления; б) восьмеричную;
Перевод в каждую из систем счисления оформить отдельной
функцией.*/

namespace Task1
{
    /// <summary>
    /// Задание 1.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            uint n;
            Console.WriteLine("Введите число в десятичной системе:");
            while (!uint.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Введите натуральное число");
            }

            Console.WriteLine($"Число в двоичной системе: {DecimalToBinary(n)}");
            Console.WriteLine($"Число в восьмиричной системе: {DecimalToOct(n)}");
        }

        /// <summary>
        /// Перевод из десятичной в двоичную систему счисления.
        /// </summary>
        /// <param name="number">Число в десятичной системе счисления.</param>
        /// <returns>string.</returns>
        private static string DecimalToBinary(uint number)
        {
            uint remainder;
            string result = string.Empty;
            while (number > 0)
            {
                remainder = number % 2;
                number /= 2;
                result = remainder.ToString() + result;
            }

            return result;
        }

        /// <summary>
        /// Перевод из десятичной в восьмиричную систему счисления.
        /// </summary>
        /// <param name="number">Число в десятичной системе счисления.</param>
        /// <returns>string.</returns>
        private static string DecimalToOct(uint number)
        {
            uint remainder;
            string result = string.Empty;
            while (number > 0)
            {
                remainder = number % 8;
                number /= 8;
                result = remainder.ToString() + result;
            }

            return result;
        }
    }
}
