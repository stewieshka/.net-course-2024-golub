using BankSystem.App.Interfaces;
using BankSystem.Domain;

namespace BankSystem.Data;

public class ClientStorage : IClientStorage
{
    public Dictionary<Client, List<Account>> Data { get; set; } = [];

    public List<Client> Get(int pageSize, int pageNumber, List<Func<Client, bool>> filters)
    {
        var query = Data.Keys.AsEnumerable();
        
        query = filters.Aggregate(query, (current, filter) => current.Where(filter));

        query = query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return query.ToList();
    }

    public void Add(Client item)
    {
        Data.Add(item, []);
    }

    public void Update(Client item)
    {
        var oldClient = Data.FirstOrDefault(x => x.Key.PhoneNumber == item.PassportId);

        Data.Remove(oldClient.Key);

        Data.Add(item, oldClient.Value);
    }

    public void Delete(Client item)
    {
        Data.Remove(item);
    }

    public List<Account> GetAccounts(Client client)
    {
        var accounts = Data[client];

        return accounts;
    }

    public void AddAccount(Client client, Account account)
    {
        var accounts = Data[client];
        
        accounts.Add(account);
    }

    public void UpdateAccount(Client client, Account oldAccount, Account newAccount)
    {
        var accounts = Data[client];

        accounts.Remove(oldAccount);
        
        accounts.Add(newAccount);
    }

    public void DeleteAccount(Client client, Account account)
    {
        var accounts = Data[client];

        accounts.Remove(account);
    }

    public int Count() => Data.Count;
}