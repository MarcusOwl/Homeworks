using System;
using System.Collections.Generic;
using System.Text;

namespace Homework7_8
{
    public struct Employee
    {
        /// <summary>
        /// ID of record
        /// </summary>
        Guid employeeGuid;
        /// <summary>
        /// Time of registration
        /// </summary>
        DateTime registrationTime;
        /// <summary>
        /// Full name
        /// </summary>
        String name;
        /// <summary>
        /// Age of employee
        /// </summary>
        Byte age;
        /// <summary>
        /// Height of employee
        /// </summary>
        Byte height;
        /// <summary>
        /// Birth date of employee
        /// </summary>
        DateOnly birthDate;
        /// <summary>
        /// Birth place of employee
        /// </summary>
        String birthPlace;

        public Guid EmployeeGuid { 
            get {
                return employeeGuid;
            }
        }
        public DateTime RegistrationTime { get
            {
                return registrationTime;
            } 
        }
        public String Name { get
            {
                return name;
            } 
        }
        public Byte Height
        {
            get
            {
                return height;
            }
        }
        public Byte Age { get
            {
                return age;
            } 
        }
        public DateOnly BirthDate { get
            {
                return birthDate;
            } 
        }
        public String BirthPlace
        {
            get
            {
                return birthPlace;
            }
        }


        /// <summary>
        /// Constructor by default
        /// </summary>
        public Employee()
        {
            string tempString = string.Empty;

            this.employeeGuid = Guid.NewGuid();
            this.registrationTime = DateTime.Now;

            Console.Clear();

            do
            {
                Console.Write($"Введите имя: ");
                tempString = Console.ReadLine();
            } while (String.IsNullOrWhiteSpace(tempString));
            this.name = tempString;

            do
            {
                Console.WriteLine($"Введите возраст: ");
                tempString = Console.ReadLine();
            } while (!Byte.TryParse(tempString, out this.age));

            do
            {
                Console.WriteLine($"Введите рост: ");
                tempString = Console.ReadLine();
            } while (!Byte.TryParse(tempString,out this.height));

            do
            {
                Console.WriteLine($"Введите дату рождения: ");
                tempString = Console.ReadLine();
            } while (!DateOnly.TryParse(tempString, out this.birthDate));

            do
            {
                Console.WriteLine($"Введите место рождения: ");
                tempString = Console.ReadLine();
            } while (String.IsNullOrEmpty(tempString));
            this.birthPlace = tempString;
        }
        /// <summary>
        /// Constructor with a string parsing
        /// </summary>
        /// <param name="s">String to parse</param>
        public Employee(string s)
        {
            string[] parts = s.Split('#');
            this.employeeGuid = Guid.Parse(parts[0]);
            this.registrationTime = DateTime.Parse(parts[1]);
            this.name = parts[2];
            this.age = byte.Parse(parts[3]);
            this.height = byte.Parse(parts[4]);
            this.birthDate = DateOnly.Parse(parts[5]);
            this.birthPlace = parts[6];
        }
        /// <summary>
        /// Print data about employee
        /// </summary>
        public void PrintEmployee()
        {
            Console.WriteLine($"ID: {this.employeeGuid}\n" +
                $"Дата регистрации (обновления): {this.registrationTime}\n" +
                $"Имя: {this.name}\n" +
                $"Возраст: {this.age}\n" +
                $"Рост: {this.height}\n" +
                $"Дата рождения: {this.birthDate}\n" +
                $"Место рождения: {this.birthPlace}\n");
        }
        /// <summary>
        /// Update Employee
        /// </summary>
        public void UpdateEmployee()
        {
            string tempString = string.Empty;
            Console.Clear();

            Console.Write($"Введите новое имя (или оставьте пустым, чтобы пропустить): ");
            tempString = Console.ReadLine();
            if (tempString.Length != 0)
                this.name = tempString;

            do
            {
                Console.WriteLine($"Введите новый возраст (или оставьте пустым, чтобы пропустить): ");
                tempString = Console.ReadLine();
                if (tempString.Length == 0)
                    break;
            } while (!Byte.TryParse(tempString, out this.age));

            do
            {
                Console.WriteLine($"Введите новый рост (или оставьте пустым, чтобы пропустить): ");
                tempString = Console.ReadLine();
                if (tempString.Length == 0)
                    break;
            } while (!Byte.TryParse(tempString, out this.height));

            do
            {
                Console.WriteLine($"Введите новую дату рождения (или оставьте пустым, чтобы пропустить): ");
                tempString = Console.ReadLine();
                if (tempString.Length == 0)
                    break;
            } while (!DateOnly.TryParse(tempString, out this.birthDate));

            Console.WriteLine($"Введите новое место рождения (или оставьте пустым, чтобы пропустить): ");
            tempString = Console.ReadLine();
            if (tempString.Length != 0)
                this.birthPlace = tempString;
        }
        /// <summary>
        /// Convert employee data to string format
        /// </summary>
        /// <returns>String with employee data</returns>
        public string GetDatabaseFormat()
        {
            return $"{this.employeeGuid}#{this.registrationTime}#{this.name}#{this.age}" +
                $"#{this.height}#{this.birthDate}#{this.birthPlace}\n";
        }
    }
}
