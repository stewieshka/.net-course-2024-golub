using System.Linq.Expressions;
using BankSystem.App.Interfaces;
using BankSystem.Domain;

namespace BankSystem.Data;

public class EmployeeStorageDb : IStorageDb<Employee>
{
    private readonly BankSystemDbContext _context = new();

    public Employee GetById(Guid id)
    {
        return _context.Employees.FirstOrDefault(x => x.Id == id);
    }

    public List<Employee> Get(int pageSize, int pageNumber, List<Expression<Func<Employee, bool>>> filters)
    {
        var query = _context.Employees.AsQueryable();
        
        query = filters.Aggregate(query, (current, filter) => current.Where(filter));

        query = query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return query.ToList();
    }

    public void Add(Employee item)
    {
        _context.Employees.Add(item);

        _context.SaveChanges();
    }

    public void Update(Employee item)
    {
        _context.Employees.Update(item);
        _context.SaveChanges();
    }

    public void Delete(Employee item)
    {
        _context.Employees.Remove(item);

        _context.SaveChanges();
    }
}