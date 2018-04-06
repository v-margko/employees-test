using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace EmployeesCoreLibrary
{
    public class EmployeesHelper
    {
        private List<EmployeeModel> employees;
        private string employeesString;
        string pathToJson;

        public EmployeesHelper(string pathToJson)
        {
            this.pathToJson = pathToJson;
            employeesString = System.IO.File.ReadAllText(pathToJson);
            employees = new List<EmployeeModel>(JsonConvert.DeserializeObject<EmployeeModel[]>(employeesString));
        }

        public List<EmployeeModel> GetEmployees()
        {
            employees.Sort((emp1, emp2) => emp1.Id.CompareTo(emp2.Id));
            return employees;
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public EmployeeModel GetEmployeeByMail(string mail)
        {
            return employees.FirstOrDefault(e => e.Mail == mail);
        }
        
        public EmployeeModel GetEmployeeByName(string name)
        {
            var names = name.Split(" ");
            return employees.FirstOrDefault(e => e.FirstName == names[0] && e.LastName == names[1]);
        }

        public void AddEmployee(EmployeeModel employeeModel)
        {
            employees.Add(employeeModel);
            System.IO.File.WriteAllText(pathToJson, JsonConvert.SerializeObject(employees));
        }

        public void AddEmployee(string empl)
        {
            var employee = JsonConvert.DeserializeObject<EmployeeModel>(empl);

            this.AddEmployee(new EmployeeModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Mail = employee.Mail,
            });
        }
    }
}
