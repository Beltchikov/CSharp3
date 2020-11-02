using CSharp3.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp3.Data
{
    public class Repository
    {
        public static IList<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee {Name = "Fred", DepartmentId = 1},
                new Employee {Name = "Joshua", DepartmentId = 1},
                new Employee {Name = "Mary", DepartmentId = 1},
                new Employee {Name = "Sam", DepartmentId = 2},
                new Employee {Name = "Serena", DepartmentId = 2},
                new Employee {Name = "Xavier"},
            };
        }

        public static IList<Department> GetDepartments()
        {
            return new List<Department>
            {
                new Department { Name = "Business", Id = 1 },
                new Department { Name = "Accounting", Id = 2 },
                new Department { Name = "It", Id = 3 },
            };
        }
    }
}
