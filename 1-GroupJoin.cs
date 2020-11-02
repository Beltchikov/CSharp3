using CSharp3.Data;
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
            var employees = Repository.GetEmployees();
            var departments = Repository.GetDepartments();

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

       
    }
}
