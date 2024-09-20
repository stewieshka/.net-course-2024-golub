using BankSystem.Domain;
using Bogus;

namespace Services;

public static class TestDataGenerator
{
    private static readonly Faker Faker = new();
    
    public static List<Client> GenerateClientList()
    {
        var clientFaker = new Faker<Client>()
            .RuleFor(a => a.FirstName, b => b.Name.FirstName())
            .RuleFor(a => a.LastName, b => b.Name.LastName())
            .RuleFor(a => a.PhoneNumber, b => b.Phone.PhoneNumber())
            .RuleFor(a => a.BirthDay, b => b.Date.PastDateOnly(70));
        
        return clientFaker.Generate(1000);
    }

    public static List<Employee> GenerateEmployeeList()
    {
        var clientFaker = new Faker<Employee>()
            .RuleFor(a => a.FirstName, b => b.Name.FirstName())
            .RuleFor(a => a.LastName, b => b.Name.LastName())
            .RuleFor(a => a.PhoneNumber, b => b.Phone.PhoneNumber())
            .RuleFor(a => a.BirthDay, b => b.Date.PastDateOnly(70))
            .RuleFor(a => a.Salary, b => b.Finance.Amount(1000, 100_000));

        return clientFaker.Generate(1000);
    }

    public static Dictionary<string, Client> GenerateClientDictionary()
    {
        var dict = new Dictionary<string, Client>();

        foreach (var _ in Enumerable.Range(1, 1000))
        {
            var firstName = Faker.Name.FirstName();
            var lastName = Faker.Name.LastName();

            var phoneNumber = Faker.Phone.PhoneNumber();
            var birthDay = Faker.Date.PastDateOnly(70);

            var client = new Client(birthDay, phoneNumber, firstName, lastName);

            dict.Add(client.PhoneNumber, client);
        }

        return dict;
    }
}