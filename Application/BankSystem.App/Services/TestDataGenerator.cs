using BankSystem.Domain;
using Bogus;

namespace BankSystem.App.Services;

public static class TestDataGenerator
{
    public static List<Client> GenerateClientsList(int amount)
    {
        var faker = new Faker<Client>()
            .RuleFor(a => a.FirstName, b => b.Name.FirstName())
            .RuleFor(a => a.LastName, b => b.Name.LastName())
            .RuleFor(a => a.BirthDay, b => b.Date.PastDateOnly(70))
            .RuleFor(a => a.PhoneNumber, b => b.Phone.PhoneNumber());

        return faker.Generate(amount);
    }

    public static List<Employee> GenerateEmployeesList(int amount)
    {
        var faker = new Faker<Employee>()
            .RuleFor(a => a.FirstName, b => b.Name.FirstName())
            .RuleFor(a => a.LastName, b => b.Name.LastName())
            .RuleFor(a => a.BirthDay, b => b.Date.PastDateOnly(70))
            .RuleFor(a => a.PhoneNumber, b => b.Phone.PhoneNumber())
            .RuleFor(a => a.Salary, b => b.Finance.Amount(1000, 100_000));

        return faker.Generate(amount);
    }

    public static Dictionary<string, Client> GenerateClientsDictionary(int amount)
    {
        var faker = new Faker<Client>()
            .RuleFor(a => a.FirstName, b => b.Name.FirstName())
            .RuleFor(a => a.LastName, b => b.Name.LastName())
            .RuleFor(a => a.BirthDay, b => b.Date.PastDateOnly(70))
            .RuleFor(a => a.PhoneNumber, b => b.Phone.PhoneNumber());

        var clients = faker.Generate(amount);

        var clientDictionary = clients.ToDictionary(client => client.PhoneNumber);

        return clientDictionary;
    }
}