using CSharp3.Data;
using CSharp3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp3
{
    public class LeftOuterJoin
    {
        public static void Demo()
        {
            var employees = Repository.GetEmployees();
            var departments = Repository.GetDepartments();

            // Method syntax
            var leftOuterJoin = employees.GroupJoin(departments, e => e.DepartmentId, d => d.Id,
                (employee, departments) => new
                {
                    employee,
                    departments
                })
                .SelectMany(r => r.departments.DefaultIfEmpty(),
                (e, d) => new
                {
                    Employee = e.employee.Name,
                    Department = d == null ? "No Depatrtment" : d.Name
                });

            // Query syntax
            //var leftOuterJoin = from employee in employees
            //                    join department in departments on employee.DepartmentId equals department.Id
            //                    into employeesAndDepartments
            //                    from de in employeesAndDepartments.DefaultIfEmpty()
            //                    select new
            //                    {
            //                        Employee = employee.Name,
            //                        Department = de == null ? "No Department" :  de.Name
            //                    };

            // 
            Console.WriteLine("LeftOuterJoin.Demo");
            foreach (var departmentEmployee in leftOuterJoin)
            {
                Console.WriteLine(departmentEmployee.Department + " " + departmentEmployee.Employee);
            }
            Console.WriteLine("--------------------------------------------");
        }
    }
}
