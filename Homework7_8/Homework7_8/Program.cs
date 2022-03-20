using System;
using System.Collections.Generic;
using System.IO;

namespace Homework7_8
{
    public class Program
    {
        const string FILE_PATH = @"database.txt";
        const string GREETINGS = "1. Вывод информации о сотруднике по id\n" +
            "2. Вывод списка записей в диапазоне\n" +
            "3. Создание новой записи";

        public static void Main(string[] args)
        {
            DatabaseService db = new DatabaseService(FILE_PATH);
            while (true)
            {
                Console.Clear();
                Console.WriteLine(GREETINGS);
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        initEmployeeSearch(db);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        db.CreateEmployee();
                        break;
                    default:
                        break;
                }
            }
        }

        static void initEmployeeSearch(DatabaseService database)
        {
            Guid guid;
            do
            {
                Console.Write($"Пожалуйста, введите GUID для поиска записи: ");
            } while (!Guid.TryParse(Console.ReadLine(), out guid));

            int index = database.GetEmployeeIdByGuid(guid);

            if (index != -1)
            {
                database.Employees[index].PrintEmployee();
                Console.WriteLine($"Нажмите 1 для удаления записи");
                Console.WriteLine($"Нажмите 2 для редактирования записи");
                Console.WriteLine($"Нажмите любую другую кнопку для возврата в основное меню");
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.D1:
                        database.DeleteEmployeeById(index);
                        break;
                    case ConsoleKey.D2:
                        database.EditEmployeeById(index);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Запись с таким GUID не найдена");
            }
        }
    }
}