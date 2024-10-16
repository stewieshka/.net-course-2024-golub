using System.Linq.Expressions;
using BankSystem.App.Interfaces;
using BankSystem.Domain;

namespace BankSystem.Data;

public class ClientStorageDb : IClientStorageDb
{
    private readonly BankSystemDbContext _context = new();

    public Client GetById(Guid id)
    {
        return _context.Clients.FirstOrDefault(x => x.Id == id);
    }
    
    public List<Client> Get(int pageSize, int pageNumber, List<Expression<Func<Client, bool>>> filters)
    {
        var query = _context.Clients.AsQueryable();
        
        query = filters.Aggregate(query, (current, filter) => current.Where(filter));

        query = query
            .OrderBy(x => x.LastName)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return query.ToList();
    }

    public void Add(Client item)
    {
        _context.Clients.Add(item);

        _context.SaveChanges();
    }

    public void Update(Client item)
    {
        _context.Clients.Update(item);
        _context.SaveChanges();
    }

    public void Delete(Client item)
    {
        _context.Clients.Remove(item);

        _context.SaveChanges();
    }

    public IReadOnlyList<Account> GetAccounts(Client client)
    {
        return _context.Accounts.Where(x => x.ClientId == client.Id).ToList();
    }

    public void AddAccount(Client client, Account account)
    {
        account.ClientId = client.Id;

        _context.Accounts.Add(account);

        _context.SaveChanges();
    }

    public void UpdateAccount(Account item)
    {
        _context.Accounts.Update(item);
        _context.SaveChanges();
    }

    public void DeleteAccount(Account account)
    {
        _context.Accounts.Remove(account);

        _context.SaveChanges();
    }

    public int Count() => _context.Clients.Count();

    public Client? MinBy<T>(Func<Client, T> selector) where T : IComparable<T>
    {
        return _context.Clients.MinBy(selector);
    }
    
    public Client? MaxBy<T>(Func<Client, T> selector) where T : IComparable<T>
    {
        return _context.Clients.MaxBy(selector);
    }

    public double Average(Func<Client, double> selector)
    {
        return _context.Clients.Average(selector);
    }
}