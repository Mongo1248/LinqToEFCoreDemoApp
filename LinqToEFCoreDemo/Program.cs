class Program
{
    static void Main()
    {
        // Ensure database is created and seeded
        using (var context = new AppDbContext())
        {
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
        }

        // Fetch and display all products
        using (var context = new AppDbContext())
        {
            var products = context.Products.ToList();
            Console.WriteLine("\nProducts in Database:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
            }
        }

        // Run LINQ Queries on In-Memory Data
        Console.WriteLine("\nEmployees earning above the average salary:");
        var highEarners = Queries.GetAboveAverageSalaryEmployees();
        foreach (var employee in highEarners)
        {
            Console.WriteLine($"{employee.Name} - ${employee.Salary}");
        }

        // Run the new LINQ query
        Console.WriteLine("\nAverage salary per department:");
        var avgSalaries = Queries.GetAverageSalaryByDepartment();
        foreach (var dept in avgSalaries)
        {
            Console.WriteLine($"{dept.DepartmentName}: ${dept.AverageSalary:F2}");
        }
    }
}
