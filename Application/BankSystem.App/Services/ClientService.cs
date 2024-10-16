using System.Linq.Expressions;
using BankSystem.App.Exceptions;
using BankSystem.App.Interfaces;
using BankSystem.Domain;

namespace BankSystem.App.Services;

public class ClientService
{
    private readonly IClientStorageDb _storageDb;

    public ClientService(IClientStorageDb storageDb)
    {
        _storageDb = storageDb;
    }

    public List<Client> Get(int pageSize, int pageNumber, List<Expression<Func<Client, bool>>> filters)
    {
        return _storageDb.Get(pageSize, pageNumber, filters);
    }
    
    public IReadOnlyList<Account> GetAccounts(Client client)
    {
        return _storageDb.GetAccounts(client);
    }
    
    public void Add(Client client)
    {
        if (client.CalculateAge() < 18)
        {
            throw new LowAgeException();
        }

        if (string.IsNullOrEmpty(client.PassportId))
        {
            throw new MyValidationException(nameof(client.PassportId));
        }
        
        _storageDb.Add(client);
        _storageDb.AddAccount(client, new Account
        {
            Amount = 0,
            Currency = new Currency
            {
                Code = "USD",
                Name = "Dollar"
            }
        });
    }

    public void AddAccount(Client client, Account account)
    {
        if (string.IsNullOrEmpty(account.Currency.Name))
        {
            throw new MyValidationException(nameof(account.Currency.Name));
        }

        if (string.IsNullOrEmpty(account.Currency.Code))
        {
            throw new MyValidationException(nameof(account.Currency.Code));
        }
        
        _storageDb.AddAccount(client, account);
    }

    public void DeleteAccount(Account account)
    {
        _storageDb.DeleteAccount(account);
    }

    public void UpdateAccount(Account account)
    {
        _storageDb.UpdateAccount(account);
    }

    public void Update(Client client)
    {
        if (client.CalculateAge() < 18)
        {
            throw new LowAgeException();
        }

        if (string.IsNullOrEmpty(client.PassportId))
        {
            throw new MyValidationException(nameof(client.PassportId));
        }
        
        _storageDb.Update(client);
    }

    public void Delete(Client client)
    {
        _storageDb.Delete(client);
    }
}