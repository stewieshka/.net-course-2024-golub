using BankSystem.Data;
using BankSystem.Domain;

namespace BankSystem.App.Services;

public class PeopleService<T>
    where T : Person
{
    protected readonly PeopleStorage<T> _storage;

    public PeopleService(PeopleStorage<T> storage)
    {
        _storage = storage;
    }

    public List<T> GetByQuery(string? firstName = null, string? lastName = null, string? phoneNumber = null,
        string? passportId = null, DateOnly? birthDateFrom = null, DateOnly? birthDateTo = null)
    {
        return _storage.GetByQuery(firstName, lastName, phoneNumber, passportId, birthDateFrom, birthDateTo);
    }
}