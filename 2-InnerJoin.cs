using CSharp3.Data;
using CSharp3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp3
{
    public class InnerJoin
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

            // Query synatx
            var innerJoin = from department in departments
                            join employee in employees on department.Id equals employee.DepartmentId
                            select new
                            {
                                Department = department,
                                Employee = employee
                            };

            Console.WriteLine("InnerJoin.Demo");
            foreach (var departmentEmployee in innerJoin)
            {
                Console.WriteLine(departmentEmployee.Department.Name + " " + departmentEmployee.Employee.Name);
            }
            Console.WriteLine("--------------------------------------------");


        }
    }
}
