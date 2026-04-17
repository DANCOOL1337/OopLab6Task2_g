using System;

namespace OopLab6
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== ТЕСТИРОВАНИЕ ЗАДАНИЯ 2 (Пересечение) ===");

            Console.WriteLine("Введите координаты первого отрезка:");
            LineSegment seg1 = new LineSegment(InputDataWithCheck.InputDouble("X1: "), InputDataWithCheck.InputDouble("Y1: "));

            Console.WriteLine("Введите координаты второго отрезка:");
            LineSegment seg2 = new LineSegment(InputDataWithCheck.InputDouble("X2: "), InputDataWithCheck.InputDouble("Y2: "));

            Console.WriteLine($"\nОтрезок 1: {seg1}");
            Console.WriteLine($"Отрезок 2: {seg2}");

            LineSegment intersect = seg1.Intersect(seg2);
            Console.WriteLine(intersect != null ? $"Пересечение: {intersect}" : "Отрезки не пересекаются.");

            Console.WriteLine("\n=== ТЕСТИРОВАНИЕ ЗАДАНИЯ 3 (Операторы) ===");

            // Тест унарного !
            LineSegment wrong = new LineSegment(15, 5);
            Console.WriteLine($"Некорректный отрезок: {wrong}. После операции ! : {!wrong}");

            // Тест приведения типов
            int yPart = seg1; // Неявное
            double xPart = (double)seg1; // Явное
            Console.WriteLine($"Отрезок 1: {seg1}. Неявный int (Y): {yPart}, Явный double (X): {xPart}");

            // Тест бинарного сложения
            int val = InputDataWithCheck.InputInt("\nВведите целое число для сложения: ");
            Console.WriteLine($"Отрезок1 + {val} (меняем X): {seg1 + val}");
            Console.WriteLine($"{val} + Отрезок1 (меняем Y): {val + seg1}");

            // Тест включения
            Console.WriteLine($"\nОтрезок1 {seg1} включает в себя Отрезок2 {seg2}?");
            Console.WriteLine(seg1 > seg2 ? "Да, включает." : "Нет, не включает.");

            Console.WriteLine("\nРабота программы завершена.");
            Console.ReadLine();
        }
    }
}