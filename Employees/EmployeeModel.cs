using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesCoreLibrary
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mail { get; set; }

        public override string ToString()
        {
            return string.Format(" ID: {0}\n First Name: {1}\n Last Name: {2}\n E-mail: {3}", Id, FirstName, LastName, Mail);
        }
    }
}
