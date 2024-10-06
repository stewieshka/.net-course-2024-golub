using BankSystem.Domain;
using BankSystem.Data.Extensions;

namespace BankSystem.Data;

public class PeopleStorage<T>
    where T : Person
{
    private readonly Dictionary<T, List<Account>> _people = [];

    public int Count() => _people.Count;
    
    public List<Account> GetAccounts(T person)
    {
        var accounts = _people[person];
        return accounts;
    }

    public List<T> GetByQuery(string firstName = null, string? lastName = null, string? phoneNumber = null,
        string? passportId = null, DateOnly? birthDateFrom = null, DateOnly? birthDateTo = null)
    {
        var query = _people.Keys.AsEnumerable();

        // хотелось бы получить комментарий по поводу этого метода расширения, ок или не ок
        query = query
            .WhereIf(!string.IsNullOrEmpty(firstName), 
                x => x.FirstName.Contains(firstName!))
            .WhereIf(!string.IsNullOrEmpty(lastName), 
                x => x.LastName.Contains(lastName!))
            .WhereIf(!string.IsNullOrEmpty(phoneNumber), 
                x => x.PhoneNumber == phoneNumber)
            .WhereIf(!string.IsNullOrEmpty(passportId), 
                x => x.PassportId == passportId)
            .WhereIf(birthDateFrom.HasValue, 
                x => x.BirthDay >= birthDateFrom!.Value)
            .WhereIf(birthDateTo.HasValue, 
                x => x.BirthDay <= birthDateTo!.Value);
        
        return query.ToList();
    }

    public void AddPerson(T entity)
    {
        _people.Add(entity, []);
    }

    public void AddAccountToPerson(T entity, Account account)
    {
        var accounts = _people[entity];

        accounts.Add(account);
    }

    public void DeleteAccount(T entity, Account account)
    {
        var accounts = _people[entity];

        var result = accounts.Remove(account);

        if (!result)
        {
            throw new Exception("Account was not deleted");
        }
    }

    public T? MyMinBy<TKey>(Func<T, TKey> selector)
    {
        return _people.Keys.MinBy(selector);
    }

    public T? MyMaxBy<TKey>(Func<T, TKey> selector)
    {
        return _people.Keys.MaxBy(selector);
    }

    public double MyAverage(Func<T, double> selector)
    {
        return _people.Keys.Average(selector);
    }
}