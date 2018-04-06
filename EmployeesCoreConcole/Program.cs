using EmployeesCoreLibrary;
using System;
using System.Text.RegularExpressions;

namespace EmployeesCoreConcole
{
    class Program
    {
        private static EmployeesHelper emplHelper;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Init();
            while (true)
            {
                Console.WriteLine("Hello");
                var command = Console.ReadLine();
                if (command == "exit")
                {
                    break;
                }

                ExecuteCommand(command);
            }
        }

        private static void Init()
        {
            var path = System.Configuration.ConfigurationManager.AppSettings["EmployeesFilePath"];
            emplHelper = new EmployeesHelper(path);
            Console.WriteLine("-- Initialized --");
        }

        private static void ExecuteCommand(string command)
        {
            string pattern = @"^(\S+)\s+(.+)";
            Match m = Regex.Match(command, pattern);
            var value = m.Groups[2].Value;
            switch (m.Groups[1].Value)
            {
                case "add":
                    emplHelper.AddEmployee(value);
                    Console.WriteLine("Added");
                    break;
                case "get":
                    Console.WriteLine(GetEmployee(value));
                    break;
            }
        }

        private static string GetEmployee(string by)
        {
            var parsed = int.TryParse(by, out int id);
            EmployeeModel result = null;
            if (parsed)
            {
                result = emplHelper.GetEmployeeById(id);
            }
            else if (by.Contains("@"))
            {
                result = emplHelper.GetEmployeeByMail(by);
            }
            else
            {
                result = emplHelper.GetEmployeeByName(by);
            }

            return result != null ? result.ToString() : "Not found!";
        }
    }
}
