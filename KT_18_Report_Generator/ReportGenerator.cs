using System;
using System.Collections.Generic;

namespace KT_18_LambdaExpressions
{
    public class ReportGenerator
    {
        public Func<int, int, int> CalculatePercentage { get; } = (part, total) => (part * 100) / total;

        public Func<int, string> ClassifyPercentage { get; } = percent =>
        {
            if (percent < 50)
            {
                return "низкий";
            }
            if (percent < 75)
            {
                return "средний";
            }
            return "высокий";
        };

        public void RunTeacherTests()
        {
            int part = 45;
            int total = 60;

            int percent = CalculatePercentage(part, total);
            string category = ClassifyPercentage(percent);

            Console.WriteLine($"Входные данные: часть = {part}, целое = {total}");
            Console.WriteLine($"1. Вычисление процента CalculatePercentage(45, 60): {percent}% (Ожидается: 75)");
            Console.WriteLine($"2. Классификация процента ClassifyPercentage(75): \"{category}\" (Ожидается: \"высокий\")");
        }

        public void DemonstrateExternalVariableCapture()
        {
            string reportTitle = "Первоначальный отчёт";

            Action printReportTitle = () => Console.WriteLine($"[Замыкание] Название отчёта: \"{reportTitle}\"");

            Console.WriteLine("Вызов лямбды сразу после создания:");
            printReportTitle();

            reportTitle = "Окончательный (изменённый) отчёт";

            Console.WriteLine("Вызов той же лямбды ПОСЛЕ изменения внешней переменной:");
            printReportTitle();
        }

        public void DemonstrateLoopVariableCapture()
        {
            Console.WriteLine("--- 4. Воспроизведение ошибки (захват общей переменной i) ---");
            List<Action> faultyActions = new List<Action>();

            for (int i = 0; i < 3; i++)
            {
                faultyActions.Add(() => Console.WriteLine($"Номер отчёта: {i}"));
            }

            Console.WriteLine("Результат выполнения 3 лямбд:");
            foreach (var action in faultyActions)
            {
                action();
            }

            Console.WriteLine("\n--- 5. Исправление (копирование в локальную переменную) ---");
            List<Action> fixedActions = new List<Action>();

            for (int i = 0; i < 3; i++)
            {
                int captured = i;
                fixedActions.Add(() => Console.WriteLine($"Номер отчёта: {captured}"));
            }

            Console.WriteLine("Результат выполнения исправленных 3 лямбд:");
            foreach (var action in fixedActions)
            {
                action();
            }
        }
    }
}