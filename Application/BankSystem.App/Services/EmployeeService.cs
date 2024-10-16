using System.Linq.Expressions;
using BankSystem.App.Exceptions;
using BankSystem.App.Interfaces;
using BankSystem.Domain;

namespace BankSystem.App.Services;

public class EmployeeService
{
    private readonly IStorageDb<Employee> _storageDb;

    public EmployeeService(IStorageDb<Employee> storageDb)
    {
        _storageDb = storageDb;
    }
    
    public List<Employee> Get(int pageSize, int pageNumber, List<Expression<Func<Employee, bool>>> filters)
    {
        return _storageDb.Get(pageSize, pageNumber, filters);
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
        
        _storageDb.Add(employee);
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
        
        _storageDb.Update(employee);
    }

    public void Delete(Employee employee)
    {
        _storageDb.Delete(employee);
    }
}