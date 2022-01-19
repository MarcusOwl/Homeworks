using System;
using System.Collections.Generic;
using System.IO;

namespace Homework6_6 
{
    public class Program
    {
        const string FILE_PATH = "database.txt";

        public static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.Write("Нажмите 1 для записи данных или 2 для просмотра базы данных: ");
                ConsoleKeyInfo choice = Console.ReadKey();
                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                        SaveData();
                        break;
                    case ConsoleKey.D2:
                        PrintData();
                        break;
                    default:
                        break;
                }
            } while(true);
        }
        private static void PrintData()
        {
            Console.Clear();
            FileInfo fileInfo = new FileInfo(FILE_PATH);
            if (fileInfo.Exists)
            {
                StreamReader streamReader = new StreamReader(FILE_PATH);
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    String[] lineValues = line.Split('#');
                    foreach (String value in lineValues)
                    {
                        Console.Write(value + "\t");
                    }
                    Console.WriteLine();
                }
                streamReader.Close();
                Console.Write("Нажмите любую кнопку для продолжения...");
            }
            else
            {
                Console.Write("Файл базы данных отсутствует! Нажмите любую кнопку для продолжения...");
            }
            Console.ReadKey();
        }
        private static void SaveData()
        {
            /*
             * 1. сбор данных
             * 2. проверка наличия файла записи
             * 3. запись
            */
            Console.Clear();
            string userData = ReadUserData();
            CheckDatabase(FILE_PATH);
            WriteUserData(userData);
            
        }
        private static string ReadUserData()
        {
            string userName;
            byte userAge;
            byte userHeight;
            DateOnly birthDate;
            string birthPlace;

            do
            {
                Console.Write("Введите имя: ");
                userName = Console.ReadLine();
            } while (String.IsNullOrWhiteSpace(userName));
            do
            {
                Console.Write("Введите возраст: ");
            } while (!Byte.TryParse(Console.ReadLine(), out userAge) && userAge <= 0);
            do
            {
                Console.Write("Введите рост: ");
            } while (!Byte.TryParse(Console.ReadLine(), out userHeight) && userHeight <= 0);
            do
            {
                Console.Write("Введите дату рождения в формате: ");
            } while(!DateOnly.TryParse(Console.ReadLine(), out birthDate));
            do
            {
                Console.Write("Введите место рождения: ");
                birthPlace = Console.ReadLine();
            } while (String.IsNullOrWhiteSpace(birthPlace));

            return "#" + userName + "#" + userAge + "#" + userHeight + "#" + birthDate + "#" + birthPlace;
        }
        private static void WriteUserData(string data)
        {
            StreamWriter streamWriter = new StreamWriter(FILE_PATH, true);
            streamWriter.WriteLine(Guid.NewGuid().ToString() + "#" + DateTime.Now.ToString() + data);
            streamWriter.Close();
        }
        private static void CheckDatabase(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                File.Create(path).Close();
            }
        }
    }
}