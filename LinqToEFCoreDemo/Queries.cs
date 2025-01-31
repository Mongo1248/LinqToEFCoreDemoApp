
class Queries
{
    public static List<Employee> GetAboveAverageSalaryEmployees()
    {
        decimal avgSalary = Data.Employees.Average(e => e.Salary);
        return Data.Employees.Where(e => e.Salary > avgSalary).ToList();
    }

    public static List<(string DepartmentName, decimal AverageSalary)> GetAverageSalaryByDepartment()
    {
        return Data.Employees
            .GroupBy(e => e.DepartmentId)
            .Select(g => (
                Data.Departments.First(d => d.Id == g.Key).Name,
                g.Average(e => e.Salary)
            )).ToList();
    }
}
