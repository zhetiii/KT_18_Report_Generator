using System;

namespace KT_18_LambdaExpressions
{
    public static class ConsoleInputHelper
    {
        public static int ReadInt(string prompt, bool allowZero = true)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new ArgumentException("Ввод не может быть пустым.");
                    }

                    if (!int.TryParse(input, out int result))
                    {
                        throw new FormatException($"Значение '{input}' не является целым числом.");
                    }

                    if (result < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(result), "Число не может быть отрицательным.");
                    }

                    if (!allowZero && result == 0)
                    {
                        throw new ArgumentException("Значение не может быть равно нулю.");
                    }

                    return result;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"[Ошибка формата]: {ex.Message} Попробуйте снова.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"[Ошибка диапазона]: {ex.Message} Попробуйте снова.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"[Ошибка ввода]: {ex.Message} Попробуйте снова.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Ошибка]: {ex.Message} Попробуйте снова.");
                }
            }
        }
    }
}