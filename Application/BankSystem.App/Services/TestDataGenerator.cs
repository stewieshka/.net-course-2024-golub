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

    public static Dictionary<Client, Account> GenerateClientsAcountsDictionary(int amount)
    {
        var faker = new Faker<Client>()
            .RuleFor(a => a.FirstName, b => b.Name.FirstName())
            .RuleFor(a => a.LastName, b => b.Name.LastName())
            .RuleFor(a => a.BirthDay, b => b.Date.PastDateOnly(70))
            .RuleFor(a => a.PhoneNumber, b => b.Phone.PhoneNumber());
        
        var clients = faker.Generate(amount);
        
        var faker2 = new Faker<Account>()
            .RuleFor(a => a.Currency, b => b.Finance.Currency().Code)
            .RuleFor(a => a.Amount, b => b.Finance.Amount(1000, 100_000));
        
        var acounts = faker2.Generate(amount);
        
        var dict = new Dictionary<Client, Account>();

        for (var i = 0; i < clients.Count; i++)
        {
            dict.Add(clients[i], acounts[i]);
        }

        return dict;
    }
}