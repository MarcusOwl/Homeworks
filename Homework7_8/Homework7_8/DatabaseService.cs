using System;
using System.Collections.Generic;
using System.Text;

namespace Homework7_8
{
    public struct DatabaseService
    {
        /// <summary>
        /// Path for DB
        /// </summary>
        String path;
        /// <summary>
        /// Array of employee records
        /// </summary>
        Employee[] employees;

        #region Getters and setters
        /// <summary>
        /// Returns true if DB file exists
        /// </summary>
        public bool FileExists
        {
            get
            {
                FileInfo fileInfo = new FileInfo(path);
                return fileInfo.Exists;
            }
        }

        /// <summary>
        /// Returns true if DB file is empty
        /// </summary>
        /// 
        public bool FileEmpty
        {
            get
            {
                FileInfo fileInfo = new FileInfo(path);
                return fileInfo.Length == 0;
            }
        }

        /// <summary>
        /// Returns number of records in DB
        /// </summary>
        private uint DatabaseSize
        {
            get
            {
                StreamReader reader = new StreamReader(path);
                uint size = 0;
                while (reader.ReadLine() != null)
                {
                    size++;
                }
                reader.Close();
                return size - 1;
            }
        }

        public Employee[] Employees
        {
            get { return employees; }
        }
        #endregion

        /// <summary>
        /// Constructor by default
        /// </summary>
        /// <param name="path">Path to database file</param>
        public DatabaseService(String path)
        {
            this.path = path;
            this.employees = null;
            if (!FileExists)
                File.Create(path).Close();
            else
                this.SyncDatabase();
        }
        /// <summary>
        /// Sync DB from file to service
        /// </summary>
        private void SyncDatabase()
        {
            this.employees = new Employee[this.DatabaseSize];
            StreamReader reader = new StreamReader(path);
            for (int i = 0; i < this.employees.Length; i++)
            {
                employees[i] = new Employee(reader.ReadLine());
            }
            reader.Close();
        }
        /// <summary>
        /// Create new employee
        /// </summary>
        public void CreateEmployee()
        {
            Employee newEmployee = new Employee();
            string newEmployeeString = newEmployee.GetDatabaseFormat();
            StreamWriter streamWriter = new StreamWriter(path, true);
            streamWriter.WriteLine(newEmployeeString);
            streamWriter.Close();
            SyncDatabase();
        }
        /// <summary>
        /// Delete employee from array
        /// </summary>
        /// <param name="id">Id of employee for deleting</param>
        public void DeleteEmployeeById(int id)
        {
            StreamWriter writer = new StreamWriter(path, false);
            for (int i = 0; i < this.employees.Length; i++)
            {
                if (i != id)
                    writer.WriteLine(this.employees[i].GetDatabaseFormat());
            }
            writer.Close();
            SyncDatabase();
        }
        /// <summary>
        /// Edit employee record by id
        /// </summary>
        /// <param name="id">Id of record</param>
        public void EditEmployeeById(int id)
        {
            employees[id].UpdateEmployee();
            SyncDatabase();
        }
        /// <summary>
        /// Get employee array id by it's guid
        /// </summary>
        /// <param name="guid">guid of employee</param>
        /// <returns></returns>
        public int GetEmployeeIdByGuid(Guid guid)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].EmployeeGuid == guid)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Print a list of all employees
        /// </summary>
        public void PrintAllRecords()
        {
            foreach(Employee employee in this.employees)
            {
                Console.WriteLine($"{employee.EmployeeGuid, 38}{employee.Name, 30}-{employee.RegistrationTime}");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Print a list of employees for period
        /// </summary>
        /// <param name="startDate">Start period</param>
        /// <param name="endDate">End period</param>
        public void PrintRecordsForPeriod(DateOnly startDate, DateOnly endDate)
        {
            Employee[] employees = GetRecordsForPeriod(startDate, endDate);
            foreach(Employee employee in employees)
            {
                Console.WriteLine($"{employee.EmployeeGuid,38}{employee.Name,30}-{employee.RegistrationTime}");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Get an array of employees for period
        /// </summary>
        /// <param name="startDate">Start period</param>
        /// <param name="endDate">End period</param>
        /// <returns></returns>
        private Employee[] GetRecordsForPeriod(DateOnly startDate, DateOnly endDate)
        {
            int recordsCount = 0;
            int recordNumber = 0;
            Employee[] employeesForPeriod = null;
            foreach(Employee employee in this.employees)
            {
                if (employee.RegistrationTime.CompareTo(startDate) > 0 && employee.RegistrationTime.CompareTo(endDate) < 0)
                {
                    recordsCount++;
                }
            }
            employeesForPeriod = new Employee[recordsCount];

            foreach(Employee employee in this.employees)
            {
                if (employee.RegistrationTime.CompareTo(startDate) > 0 && employee.RegistrationTime.CompareTo(endDate) < 0)
                {
                    employeesForPeriod[recordNumber] = employee;
                    recordNumber++;
                }
            }
            return employeesForPeriod;
        }
    }
}
