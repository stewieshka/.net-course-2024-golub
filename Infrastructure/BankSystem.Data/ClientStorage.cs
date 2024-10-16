using BankSystem.App.Interfaces;
using BankSystem.Domain;

namespace BankSystem.Data;

public class ClientStorage : IClientStorage
{
    private readonly Dictionary<Client, List<Account>> _data = [];

    public List<Client> Get(int pageSize, int pageNumber, List<Func<Client, bool>> filters)
    {
        var query = _data.Keys.AsEnumerable();
        
        query = filters.Aggregate(query, (current, filter) => current.Where(filter));

        query = query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return query.ToList();
    }

    public void Add(Client item)
    {
        _data.Add(item, []);
    }

    public void Update(Client item)
    {
        var accounts = _data[item];

        _data.Remove(item);

        _data.Add(item, accounts);
    }

    public void Delete(Client item)
    {
        _data.Remove(item);
    }

    public IReadOnlyList<Account> GetAccounts(Client client)
    {
        return _data[client];
    }

    public void AddAccount(Client client, Account account)
    {
        var accounts = _data[client];
        
        accounts.Add(account);
    }

    public void UpdateAccount(Client client, Account oldAccount, Account newAccount)
    {
        var accounts = _data[client];

        accounts.Remove(oldAccount);
        
        accounts.Add(newAccount);
    }

    public void DeleteAccount(Client client, Account account)
    {
        var accounts = _data[client];

        accounts.Remove(account);
    }

    public int Count() => _data.Count;

    public Client? MinBy<T>(Func<Client, T> selector) where T : IComparable<T>
    {
        return _data.Keys.MinBy(selector);
    }
    
    public Client? MaxBy<T>(Func<Client, T> selector) where T : IComparable<T>
    {
        return _data.Keys.MaxBy(selector);
    }

    public double Average(Func<Client, double> selector)
    {
        return _data.Keys.Average(selector);
    }
}