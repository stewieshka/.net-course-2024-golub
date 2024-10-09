using BankSystem.App.Exceptions;
using BankSystem.App.Interfaces;
using BankSystem.Domain;

namespace BankSystem.App.Services;

public class EmployeeService
{
    private readonly IStorage<Employee> _storage;

    public EmployeeService(IStorage<Employee> storage)
    {
        _storage = storage;
    }
    
    public List<Employee> Get(int pageSize, int pageNumber, List<Func<Employee, bool>> filters)
    {
        return _storage.Get(pageSize, pageNumber, filters);
    }
    
    public void Add(Employee employee)
    {
        if (employee.CalculateAge() < 18)
        {
            throw new LowAgeException();
        }

        if (string.IsNullOrEmpty(employee.PassportId))
        {
            throw new MyValidationException(nameof(employee.PassportId));
        }
        
        _storage.Add(employee);
    }

    public void Update(Employee employee)
    {
        if (employee.CalculateAge() < 18)
        {
            throw new LowAgeException();
        }

        if (string.IsNullOrEmpty(employee.PassportId))
        {
            throw new MyValidationException(nameof(employee.PassportId));
        }
        
        _storage.Update(employee);
    }

    public void Delete(Employee employee)
    {
        _storage.Delete(employee);
    }
}