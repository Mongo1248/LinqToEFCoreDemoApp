class Program
{
    static void Main()
    {
        using var context = new AppDbContext();
        context.Database.EnsureCreated();

        if (!context.Products.Any())
        {
            context.Products.AddRange(
                new Product { Name = "Laptop", Price = 1200.99m },
                new Product { Name = "Mouse", Price = 25.50m },
                new Product { Name = "Keyboard", Price = 45.75m }
            );
            context.SaveChanges();
        }

        Console.WriteLine("\nProducts in Database:");
        foreach (var p in context.Products.ToList())
            Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Price: {p.Price:C}");

        Console.WriteLine("\nEmployees earning above the average salary:");
        foreach (var e in Queries.GetAboveAverageSalaryEmployees())
            Console.WriteLine($"{e.Name} - ${e.Salary}");

        Console.WriteLine("\nAverage salary per department:");
        foreach (var d in Queries.GetAverageSalaryByDepartment())
            Console.WriteLine($"{d.DepartmentName}: ${d.AverageSalary:F2}");
    }
}

