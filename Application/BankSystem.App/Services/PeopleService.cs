using BankSystem.App.Exceptions;
using BankSystem.Data;
using BankSystem.Domain;

namespace BankSystem.App.Services;

public class PeopleService<T>
    where T : Person
{
    private readonly PeopleStorage<T> _storage;

    public PeopleService(PeopleStorage<T> storage)
    {
        _storage = storage;
    }

    public List<T> GetByQuery(string? firstName = null, string? lastName = null, string? phoneNumber = null,
        string? passportId = null, DateOnly? birthDateFrom = null, DateOnly? birthDateTo = null)
    {
        return _storage.GetByQuery(firstName, lastName, phoneNumber, passportId, birthDateFrom, birthDateTo);
    }
    
    public List<Account> GetAccounts(T person)
    {
        return _storage.GetAccounts(person);
    }
    
    public void Add(T person)
    {
        if (person.CalculateAge() < 18)
        {
            throw new LowAgeException();
        }

        if (string.IsNullOrEmpty(person.PassportId))
        {
            throw new MyValidationException(nameof(person.PassportId));
        }
        
        _storage.AddPerson(person);
        _storage.AddAccountToPerson(person, new Account
        {
            Amount = 0,
            Currency = new Currency
            {
                Code = "USD",
                Name = "Dollar"
            }
        });
    }

    public void AddAccount(T person, Account account)
    {
        if (string.IsNullOrEmpty(account.Currency.Name))
        {
            throw new MyValidationException(nameof(account.Currency.Name));
        }

        if (string.IsNullOrEmpty(account.Currency.Code))
        {
            throw new MyValidationException(nameof(account.Currency.Code));
        }
        
        _storage.AddAccountToPerson(person, account);
    }

    public void DeleteAccount(T person, Account account)
    {
        _storage.DeleteAccount(person, account);
    }

    public void Update(Account account, decimal? amount = null, Currency? currency = null)
    {
        account.Amount = amount ?? account.Amount;
        account.Currency = currency ?? account.Currency;
    }
}