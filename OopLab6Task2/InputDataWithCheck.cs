using System;

namespace OopLab6
{
    class InputDataWithCheck
    {
        static public double InputDouble(string msg)
        {
            double res;
            while (!double.
                TryParse(Console.ReadLine(), out res))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Введите число.");
                Console.ResetColor();
                Console.WriteLine(msg);
            }
            return res;
        }

        static public int InputInt(string msg)
        {
            int res;
            while (!int.TryParse(Console.ReadLine(), out res))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! " +
                    "Введите целое число.");
                Console.ResetColor();
                Console.WriteLine(msg);
            }
            return res;
        }
    }
}
