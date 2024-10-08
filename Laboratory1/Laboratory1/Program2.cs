﻿namespace Laboratory1;

public class Program2
{
    public static void RunTask()
    {
        // Масив з 10 цілих чисел
        int[] a = { 5, 7, 2, 7, 10, 10, 4, 3, 10, 6 };
        int arraySize = a.Length;
                
        // Виводимо створений масив 10 цілих чисел
        PrintArray("\nМасив \"a\" 10 цілих чисел:", a);
        
        // Знаходимо найбільший елемент масиву
        int maxElement = a.Max();
        Console.WriteLine("Найбільше значення масиву: {0}", maxElement);
        
        // Підраховуємо кількість повторень найбільшого значення
        Console.WriteLine("Порядкові номери елементів з найбільшим значенням, які повторюються:");
        int numOfRepeats = 0;
        for (int i = 0; i < arraySize; i++)
        {
            if (a[i] == maxElement)
            {
                numOfRepeats++;
                if (numOfRepeats > 1) // Умова, що виведення буде лише повторювальних номерів
                {
                    Console.WriteLine("a[{0}] = {1}", i, a[i]); // Тобто перший елемент не повторююється, тому і не виводиться
                }
            }
        }
        Console.WriteLine("Кількість повторень найбільшого значення: {0}", numOfRepeats-1);
        
        // Упорядковуємо масив за спаданням
        Array.Sort(a); // Сортуємо за зростанням
        Array.Reverse(a); // Переводимо у спадання
        PrintArray("\nУпорядкований масив за спаданням:", a);
        
        // Введення інтервалу (x, y]
        int x, y;
        x = ReadIntValue("Введіть значення x: ");
        y = ReadIntValue("Введіть значення y: ");
        
        // Знаходимо добуток елементів, що належать інтервалу (x, y]
        int product = 1;
        bool foundInInterval = false;

        for (int i = 0; i < arraySize; i++)
        {
            if (a[i] > x && a[i] <= y)
            {
                product *= a[i];
                foundInInterval = true;
            }
            else
            {
                a[i] = 0; // Заміна всіх інших елементів на нулі
            }
        }

        // Якщо не знайшли жодного елемента в інтервалі, ставимо добуток 0
        if (!foundInInterval)
        {
            product = 0;
        }

        Console.WriteLine("\nДобуток елементів у інтервалі ({0}, {1}]: {2}", x, y, product);
        PrintArray("\nМасив після заміни елементів, що не належать інтервалу, на нулі:", a);
    }
    // Метод для виведення масиву
    public static void PrintArray(string header, int[] a) {
        Console.WriteLine(header);
        int i;
        for (i = 0; i < a.Length; ++i)
        {
            Console.Write("\t" + a[i]);
        }
        Console.WriteLine();
    }
    
    // Метод для перевірки введення
    static int ReadIntValue(string message)
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
}