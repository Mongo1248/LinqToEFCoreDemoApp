

class Department
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public List<Employee> Employees { get; set; } = new();
}

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;  // Default value to avoid null
    public int DepartmentId { get; set; }
    public decimal Salary { get; set; }

    public Department Department { get; set; } = null!;  // EF Core handles assignment
}



