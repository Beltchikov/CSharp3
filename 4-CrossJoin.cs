using CSharp3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp3
{
    public class CrossJoin
    {
        public static void Demo()
        {
            var employees = Repository.GetEmployees();
            var departments = Repository.GetDepartments();

            // Method syntax
            //var innerJoin = departments.Join(employees, d => d.Id, e => e.DepartmentId,
            //    (department, employee) => new
            //    {
            //        Department = department,
            //        Employee = employee
            //    });

            // Query syntax
            var crossJoin = from department in departments
                            from employee in employees 
                            select new
                            {
                                Department = department,
                                Employee = employee
                            };

            Console.WriteLine("CrossJoin.Demo");
            foreach (var departmentEmployee in crossJoin)
            {
                Console.WriteLine(departmentEmployee.Department.Name + " " + departmentEmployee.Employee.Name);
            }
            Console.WriteLine("--------------------------------------------");


        }
    }
}
