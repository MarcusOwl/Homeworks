using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework4_8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int userChoice;
            while (true)
            {
                do {
                    Console.Clear();
                    Console.WriteLine("Задание 1. Случайная матрица");
                    Console.WriteLine("Задание 2. Наименьший элемент в последовательности");
                    Console.WriteLine("Задание 3. Игра «Угадай число»");
                    Console.Write("Выберите номер задания: ");
                } while (!Int32.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > 3);

                switch (userChoice)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    default:
                        break;
                }
            }
        }

        static void Task1()
        {
            int rows;
            do { 
                Console.Write("Введите количество строк в таблице: "); 
            } while (!Int32.TryParse(Console.ReadLine(), out rows) && rows <= 0);

            int columns;
            do
            {
                Console.Write("Введите количество столбцов: ");
            } while (!Int32.TryParse(Console.ReadLine(), out columns) && columns <= 0);

            Random random = new Random();
            int sum = 0;

            int[,] matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(100);
                    sum = sum + matrix[i, j];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j],5} ");
                }
                Console.Write("\n");
            }

            Console.WriteLine($"Сумма всех элементов: {sum}");
            Console.ReadKey();
        }

        static void Task2()
        {
            int range;
            do {
                Console.Write("Введите длину последовательности: ");
            } while (!Int32.TryParse(Console.ReadLine(), out range) && range <= 0);

            int[] matrix = new int[range];

            for (int i = 0; i < range; i++)
            {
                do {
                    Console.Write($"Введите {i + 1} число последовательности: ");
                } while (!Int32.TryParse(Console.ReadLine(), out matrix[i]));
            }

            int minValue = Int32.MaxValue;

            foreach (int e in matrix)
            {
                if (minValue > e)
                {
                    minValue = e;
                }
            }

            Console.WriteLine($"Минимальное значение: {minValue}");
            Console.ReadKey();
        }

        static void Task3()
        {
            int range;
            do {
                Console.Write("Введите значение диапазона: ");
            } while (!Int32.TryParse(Console.ReadLine(), out range) || range <= 0);

            Random rand = new Random();
            int hiddenNumber = rand.Next(range);
            int playerNumber = 0;

            do {
                do {
                    Console.Write("Введите загаданное число: ");
                    String tempString = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(tempString))
                    {
                        Console.WriteLine($"Жаль, что вы не угадали число {hiddenNumber}");
                        Console.ReadKey();
                        return;
                    } else 
                    if (Int32.TryParse(tempString, out playerNumber))
                    {
                        break;
                    }

                } while (true);

                if (playerNumber == hiddenNumber)
                {
                    Console.WriteLine("Вы угадали! Поздравляем!");
                    break;
                }

            } while (true);
            Console.ReadKey();
        }
    }
}