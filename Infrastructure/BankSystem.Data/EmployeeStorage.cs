using BankSystem.App.Interfaces;
using BankSystem.Domain;

namespace BankSystem.Data;

public class EmployeeStorage : IStorage<Employee>
{
    private readonly List<Employee> _employees = [];

    public List<Employee> Get(int pageSize, int pageNumber, List<Func<Employee, bool>> filters)
    {
        var query = _employees.AsEnumerable();
        
        query = filters.Aggregate(query, (current, filter) => current.Where(filter));

        query = query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return query.ToList();
    }

    public void Add(Employee item)
    {
        _employees.Add(item);
    }

    public void Update(Employee item)
    {
        var oldEmployee = _employees.FirstOrDefault(x => x.PassportId == item.PassportId);

        _employees.Remove(oldEmployee);
        
        _employees.Add(item);
    }

    public void Delete(Employee item)
    {
        _employees.Remove(item);
    }
}