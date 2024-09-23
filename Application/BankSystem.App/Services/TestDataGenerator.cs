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
        var dict = new Dictionary<string, Client>();

        var faker = new Faker();
        
        foreach (var _ in Enumerable.Range(1, amount))
        {
            var client = new Client
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                BirthDay = faker.Date.PastDateOnly(70),
                PhoneNumber = faker.Phone.PhoneNumber()
            };
            
            dict.Add(client.PhoneNumber, client);
        }

        return dict;
    }
}