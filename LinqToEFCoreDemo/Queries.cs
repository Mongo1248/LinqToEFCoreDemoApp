
class Queries
{
    public static List<Employee> GetAboveAverageSalaryEmployees()
    {
        decimal averageSalary = Data.Employees.Average(e => e.Salary);

        return Data.Employees.Where(e => e.Salary > averageSalary).ToList();
    }


    public static List<(string DepartmentName, decimal AverageSalary)> GetAverageSalaryByDepartment()
    {
        return Data.Employees
            .GroupBy(e => e.DepartmentId)
            .Select(g => (
                DepartmentName: Data.Departments.First(d => d.Id == g.Key).Name,
                AverageSalary: g.Average(e => e.Salary)
            )).ToList();
    }

}
