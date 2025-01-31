using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

class Queries
{
    public static List<Employee> GetAboveAverageSalaryEmployees(AppDbContext context)
    {
        decimal avgSalary = context.Employees.Average(e => e.Salary);
        return context.Employees.Where(e => e.Salary > avgSalary).ToList();
    }

    public static List<(string DepartmentName, decimal AverageSalary)> GetAverageSalaryByDepartment(AppDbContext context)
    {
        var results = context.Employees
            .Include(e => e.Department)
            .Where(e => e.Department != null) // Ensure Department is loaded
            .GroupBy(e => e.DepartmentId)
            .Select(g => new
            {
                DepartmentName = g.First().Department!.Name ?? "Unknown", // Ensure non-null value
                AverageSalary = g.Average(e => e.Salary)
            })
            .ToList();

        return results.Select(r => (r.DepartmentName!, r.AverageSalary)).ToList(); // Null-forgiving operator
    }




}
