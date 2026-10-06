using System;

namespace KT_18_LambdaExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("==================================================");
            Console.WriteLine("  КТ №18: Лямбда-выражения (Вариант 1)           ");
            Console.WriteLine("==================================================\n");

            ReportGenerator generator = new ReportGenerator();

            Console.WriteLine("=== 1. Проверка по контрольным ключам ===");
            generator.RunTeacherTests();

            Console.WriteLine("\n=== 2. Захват внешней измеряемой переменной ===");
            generator.DemonstrateExternalVariableCapture();

            Console.WriteLine("\n=== 3. Захват переменной цикла for ===");
            generator.DemonstrateLoopVariableCapture();

            Console.WriteLine("\n=== 4. Интерактивный ручной ввод ===");
            RunInteractiveSession(generator);

            Console.WriteLine("\nПрограмма завершена.");
        }

        private static void RunInteractiveSession(ReportGenerator generator)
        {
            while (true)
            {
                Console.WriteLine("\n-- Ввод данных для генерации отчёта --");
                int part = ConsoleInputHelper.ReadInt("Введите часть (числитель): ");
                int total = ConsoleInputHelper.ReadInt("Введите целое (знаменатель, > 0): ", allowZero: false);

                int percent = generator.CalculatePercentage(part, total);
                string category = generator.ClassifyPercentage(percent);

                Console.WriteLine($"\n[Результат]: Рассчитанный процент: {percent}%, Категория: \"{category}\"");

                Console.Write("\nХотите сделать ещё один расчёт? (y/n): ");
                string choice = Console.ReadLine()?.Trim().ToLower();
                if (choice != "y" && choice != "yes" && choice != "да")
                {
                    break;
                }
            }
        }
    }
}
