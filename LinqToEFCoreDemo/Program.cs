using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using var context = new AppDbContext();
        context.Database.EnsureCreated();

        // Seed Departments
        if (!context.Departments.Any())
        {
            context.Departments.AddRange(
                new Department { Name = "IT" },
                new Department { Name = "HR" },
                new Department { Name = "Finance" }
            );
            context.SaveChanges();
        }

        // Seed Employees
        if (!context.Employees.Any())
        {
            var departments = context.Departments.ToList();
            context.Employees.AddRange(
                new Employee { Name = "Alice", DepartmentId = departments[0].Id, Salary = 60000 },
                new Employee { Name = "Bob", DepartmentId = departments[0].Id, Salary = 80000 },
                new Employee { Name = "Charlie", DepartmentId = departments[1].Id, Salary = 50000 },
                new Employee { Name = "David", DepartmentId = departments[1].Id, Salary = 55000 },
                new Employee { Name = "Eve", DepartmentId = departments[2].Id, Salary = 75000 },
                new Employee { Name = "Frank", DepartmentId = departments[2].Id, Salary = 90000 }
            );
            context.SaveChanges();
        }

        Console.WriteLine("\nEmployees earning above the average salary:");
        foreach (var e in Queries.GetAboveAverageSalaryEmployees(context))
            Console.WriteLine($"{e.Name} - ${e.Salary}");

        Console.WriteLine("\nAverage salary per department:");
        foreach (var d in Queries.GetAverageSalaryByDepartment(context))
            Console.WriteLine($"{d.DepartmentName}: ${d.AverageSalary:F2}");
    }
}

