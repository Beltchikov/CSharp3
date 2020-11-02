using CSharp3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp3
{
    public class GroupJoin
    {
        public static void Demo()
        {
            var employees = GetEmployees();
            var departments = GetDepartments();

            // Method syntax
            var employeesByDepartmentList = departments.GroupJoin(employees, d => d.Id, e => e.DepartmentId,
                (department, employees) => new
                {
                    Department = department,
                    Employees = employees
                });

            // Query syntax
            //var employeesByDepartmentList = from department in departments
            //                                join employee in employees on department.Id equals employee.DepartmentId
            //                                into departmentJoinedWithEmployees
            //                                select new
            //                                {
            //                                    Department = department,
            //                                    Employees = departmentJoinedWithEmployees
            //                                };

            Console.WriteLine("GroupJoin.Demo");
            foreach (var employeesByDepartment in employeesByDepartmentList)
            {
                Console.WriteLine(employeesByDepartment.Department.Name);
                foreach (var employee in employeesByDepartment.Employees)
                {
                    Console.WriteLine(" " + employee.Name);
                }
            }
            Console.WriteLine("--------------------------------------------");
        }

        private static IList<Employee> GetEmployees()
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

        private static IList<Department> GetDepartments()
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
