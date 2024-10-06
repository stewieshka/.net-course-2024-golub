using BankSystem.App.Exceptions;
using BankSystem.App.Services;
using BankSystem.Data;
using BankSystem.Domain;

public class ClientService : PeopleService<Client>
{
    public ClientService(PeopleStorage<Client> storage)
        : base(storage) {}

    public List<Account> GetAccounts(Client client)
    {
        return _storage.GetAccounts(client);
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
        
        _storage.AddPerson(client);
        _storage.AddAccountToPerson(client, new Account
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
        
        _storage.AddAccountToPerson(client, account);
    }

    public void DeleteAccount(Client client, Account account)
    {
        _storage.DeleteAccount(client, account);
    }

    public void Update(Account account, decimal? amount = null, Currency? currency = null)
    {
        account.Amount = amount ?? account.Amount;
        account.Currency = currency ?? account.Currency;
    }
}