
class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public decimal Salary { get; set; }
}

