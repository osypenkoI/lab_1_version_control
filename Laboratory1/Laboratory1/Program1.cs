namespace Laboratory1
{
    public class Program1
    {
        public static void RunTask()
        { 
            // Введення кількості рядків для пошуку підрядка
            Console.Write("\nВведіть кількість рядків для пошуку підрядка: ");
            int numberOfLines;
            while (!int.TryParse(Console.ReadLine(), out numberOfLines) || numberOfLines <= 0)
            {
                Console.Write("\nНеправильний ввід. Введіть правильне число: ");
            }

            // Введення рядків
            string[] lines = new string[numberOfLines];
            Console.WriteLine("\nВведіть рядки (щоб завершити введення передчасно, введіть \"exit\"):");

            for (int i = 0; i < numberOfLines; i++)
            {
                Console.Write($"Рядок {i + 1}: ");
                string input = Console.ReadLine();
                
                // Перевіряємо на введення команди "exit" для завершення
                if (input.Trim().ToLower() == "exit")
                {
                    Console.WriteLine("Введення рядків завершено достроково.");
                    numberOfLines = i;
                    break;
                }

                // Перевіряємо, щоб рядок не був порожнім
                while (string.IsNullOrWhiteSpace(input))
                {
                    Console.Write("Рядок не може бути порожнім. Введіть рядок ще раз: ");
                    input = Console.ReadLine();
                }

                lines[i] = input;
            }

            // Введення фрагмента для пошуку
            Console.Write("Введіть строковий фрагмент для пошуку (або залиште порожнім для відмови від пошуку): ");
            string searchFragment = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(searchFragment))
            {
                Console.WriteLine("Фрагмент для пошуку не введено. Пошук скасовано.");
            }
            else
            {
                // Пошук і виведення результатів
                Console.WriteLine("\nРядки, що містять фрагмент:");
                bool found = false;
                int foundCount = 0;

                for (int i = 0; i < numberOfLines; i++)
                {
                    if (lines[i].IndexOf(searchFragment, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine($"Рядок {i + 1}: {lines[i]}");
                        found = true;
                        foundCount++;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Жоден рядок не містить заданий фрагмент.");
                }
                else
                {
                    Console.WriteLine($"\nЗнайдено {foundCount} рядків, що містять фрагмент \"{searchFragment}\".");
                }
            }

            // Завершення програми
            Console.WriteLine("\nНатисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}
