using System;

namespace Laboratory1
{
    public class MainProgramLab1
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exitRequested = false;

            while (!exitRequested)
            {
                // Виведення меню
                ShowMenu();

                // Зчитування вибору користувача
                Console.Write("\nВведіть ваш вибір: ");
                string input = Console.ReadLine()?.Trim();

                // Обробка вибору
                switch (input)
                {
                    case "1":
                        Program1.RunTask();
                        break;
                    case "2":
                        Program2.RunTask();
                        break;
                    case "3":
                        Program3.RunTask();
                        break;
                    case "4":
                        Program4.RunTask();
                        break;
                    case "0":
                        Console.WriteLine("До побачення! Натисніть будь-яку клавішу для виходу...");
                        exitRequested = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("❌ Невірний вибір. Будь ласка, спробуйте ще раз.\n");
                        Console.ResetColor();
                        break;
                }

                if (!exitRequested)
                {
                    Console.WriteLine("\nНатисніть будь-яку клавішу, щоб продовжити...");
                    Console.ReadKey();
                    Console.Clear(); // Очищення екрану для зручності
                }
            }
        }

        /// <summary>
        /// Виводить меню на консоль
        /// </summary>
        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("┌────────────────────────────────┐");
            Console.WriteLine("│    Меню лабораторних завдань   │");
            Console.WriteLine("└────────────────────────────────┘");
            Console.ResetColor();

            Console.WriteLine("1. Завдання 1");
            Console.WriteLine("2. Завдання 2");
            Console.WriteLine("3. Завдання 3");
            Console.WriteLine("4. Завдання 4");
            Console.WriteLine("0. Вихід");
        }
    }
}
