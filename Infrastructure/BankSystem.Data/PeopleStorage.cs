using BankSystem.Domain;

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

    public List<T> GetByQuery(string? firstName = null, string? lastName = null, string? phoneNumber = null,
        string? passportId = null, DateOnly? birthDateFrom = null, DateOnly? birthDateTo = null)
    {
        var query = _people.Keys.AsEnumerable();

        if (!string.IsNullOrEmpty(firstName))
        {
            query = query.Where(x => x.FirstName.Contains(firstName));
        }

        if (!string.IsNullOrEmpty(lastName))
        {
            query = query.Where(x => x.FirstName.Contains(lastName));
        }

        if (!string.IsNullOrEmpty(phoneNumber))
        {
            query = query.Where(x => x.PhoneNumber == phoneNumber);
        }

        if (!string.IsNullOrEmpty(passportId))
        {
            query = query.Where(x => x.PassportId == passportId);
        }

        if (birthDateFrom.HasValue)
        {
            query = query.Where(x => x.BirthDay >= birthDateFrom.Value);
        }

        if (birthDateTo.HasValue)
        {
            query = query.Where(x => x.BirthDay <= birthDateTo.Value);
        }

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