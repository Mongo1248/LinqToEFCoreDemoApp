
class Data
{
    public static List<Department> Departments = new List<Department>
    {
        new Department { Id = 1, Name = "IT" },
        new Department { Id = 2, Name = "HR" },
        new Department { Id = 3, Name = "Finance" }
    };

    public static List<Employee> Employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "Alice", DepartmentId = 1, Salary = 60000 },
        new Employee { Id = 2, Name = "Bob", DepartmentId = 1, Salary = 80000 },
        new Employee { Id = 3, Name = "Charlie", DepartmentId = 2, Salary = 50000 },
        new Employee { Id = 4, Name = "David", DepartmentId = 2, Salary = 55000 },
        new Employee { Id = 5, Name = "Eve", DepartmentId = 3, Salary = 75000 },
        new Employee { Id = 6, Name = "Frank", DepartmentId = 3, Salary = 90000 }
    };
}
