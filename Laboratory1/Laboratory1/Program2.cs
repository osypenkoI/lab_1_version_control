﻿namespace Laboratory1
{
    public class Program2
    {
        public static void RunTask()
        {
            // Масив з 10 цілих чисел
            int[] a = { 5, 7, 2, 7, 10, 10, 4, 3, 10, 6 };
            
            // Виводимо створений масив 10 цілих чисел
            PrintArray("\nМасив \"a\" 10 цілих чисел:", a);

            // Знаходимо найбільший елемент масиву
            int maxElement = a.Max();
            Console.WriteLine("Найбільше значення масиву: {0}", maxElement);

            // Знаходимо та виводимо порядкові номери елементів з найбільшим значенням, які повторюються
            var indices = a.Select((value, index) => new { value, index })
                           .Where(x => x.value == maxElement)
                           .Select(x => x.index)
                           .Skip(1); // Пропускаємо перший елемент
            
            // Виводимо індекси повторюваних значень
            Console.WriteLine("Порядкові номери елементів з найбільшим значенням, які повторюються:");
            foreach (var index in indices)
            {
                Console.WriteLine($"a[{index}] = {maxElement}");
            }
            Console.WriteLine($"Кількість повторень найбільшого значення: {indices.Count()}");

            // Упорядковуємо масив за спаданням
            int[] sortedArray = SortArrayDescending(a);
            PrintArray("\nУпорядкований масив за спаданням:", sortedArray);

            // Введення інтервалу (x, y]
            int x = ReadIntValue("Введіть значення x: ");
            int y = ReadIntValue("Введіть значення y: ");

            // Знаходимо добуток елементів, що належать інтервалу (x, y]
            int product = CalculateProductInRange(sortedArray, x, y);

            // Виведення результатів
            Console.WriteLine("\nДобуток елементів у інтервалі ({0}, {1}]: {2}", x, y, product);
            PrintArray("\nМасив після заміни елементів, що не належать інтервалу, на нулі:", sortedArray);
        }

        // Метод для виведення масиву
        public static void PrintArray(string header, int[] array)
        {
            Console.WriteLine(header);
            foreach (var item in array)
            {
                Console.Write("\t" + item);
            }
            Console.WriteLine();
        }

        // Метод для сортування масиву за спаданням
        public static int[] SortArrayDescending(int[] array)
        {
            int[] sortedArray = (int[])array.Clone(); // Створюємо копію масиву
            Array.Sort(sortedArray);
            Array.Reverse(sortedArray);
            return sortedArray;
        }

        // Метод для перевірки введення
        public static int ReadIntValue(string message)
        {
            int result;
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                // Перевіряємо, чи є введене значення цілим числом
                if (int.TryParse(input, out result))
                {
                    break; // Виходимо з циклу, якщо введено коректне значення
                }
                else
                {
                    Console.WriteLine("Невірне введення! Будь ласка, введіть ціле число.");
                }
            }

            return result;
        }

        // Метод для розрахунку добутку елементів у інтервалі (x, y]
        public static int CalculateProductInRange(int[] array, int x, int y)
        {
            int product = 1;
            bool foundInInterval = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > x && array[i] <= y)
                {
                    product *= array[i];
                    foundInInterval = true;
                }
                else
                {
                    array[i] = 0; // Заміна всіх інших елементів на нулі
                }
            }

            // Якщо не знайшли жодного елемента в інтервалі, ставимо добуток 0
            return foundInInterval ? product : 0;
        }
    }
}
