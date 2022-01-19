using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework5_5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string sentence;
            do
            {
                Console.WriteLine($"Введите предложение ниже");
                sentence = Console.ReadLine();
                Console.Clear();
            } while (sentence.Length == 0);

            string[] array = StringToArray(sentence);
            PrintArray(array);
            Console.WriteLine($"Количество слов: {array.Length}");
            Console.WriteLine("Инвертированная последовательность слов: " + ReverseSentence(sentence));
        }
        /// <summary>
        /// Метод, который преобразует строку в массив слов
        /// </summary>
        /// <param name="str">Исходная строка</param>
        /// <returns>Массив слов</returns>
        static string[] StringToArray(string str)
        {
            String sentence = str;
            String[] words;
            sentence = DeletePunctuation(sentence);
            sentence = DeleteUnnecessarySpaces(sentence);
            words = sentence.Split(' ');
            return words;
        }
        /// <summary>
        /// Метод, который удаляет из строки все знаки пунктуации
        /// </summary>
        /// <param name="str">Исходная строка, из которой необходимо удалить символы пунктуации</param>
        /// <returns>Возвращает строку с удалёнными из нее знаками пунктуации</returns>
        static string DeletePunctuation(string str)
        {
            for (int i = str.Length - 1; i != 0; i--)
            {
                if (Char.IsPunctuation(str[i]) || Char.)
                {
                    str = str.Remove(i, 1);
                }
            }
            return str;
        }
        /// <summary>
        /// Метод, который удаляет из строки лишние пробелы 
        /// </summary>
        /// <param name="str">Строка для обработки</param>
        /// <returns>Обработанная строка</returns>
        static string DeleteUnnecessarySpaces(string str)
        {
            for (int i = str.Length - 1; i != -1; i--)
            {
                if (str[i] == ' ' && str[i] == str[i + 1])
                {
                    str = str.Remove(i, 1);
                }
            }
            return str;
        }
        /// <summary>
        /// Вывод массива строк в консоль
        /// </summary>
        /// <param name="array">Массив строк, который необходимо вывести в консоль</param>
        static void PrintArray(string[] array)
        {
            foreach (string e in array)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Метод, который меняет последовательность слов внутри предложения (без учёта пунктуации)
        /// </summary>
        /// <param name="sentence">Исходная строка</param>
        /// <returns>Результат инвертирования</returns>
        static string ReverseSentence(string sentence)
        {
            string[] words = StringToArray(sentence);
            Array.Reverse(words);
            return String.Join(" ", words);
        }
    }
}