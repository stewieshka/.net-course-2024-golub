using BankSystem.App.Services;
using BankSystem.Data;
using BankSystem.Domain;

namespace BankSystem.App.Tests;

public class EquivalenceTests
{
    private static readonly Random Random = new();
    
    [Fact]
    public void GetHashCodeNecessityPositiveTest()
    {
        // Arrange
        var dict = TestDataGenerator.GenerateClientsAcountsDictionary(1000);

        var lastClient = dict.Last();

        var client = new Client
        {
            FirstName = lastClient.Key.FirstName,
            LastName = lastClient.Key.LastName,
            BirthDay = lastClient.Key.BirthDay,
            PhoneNumber = lastClient.Key.PhoneNumber,
            PassportId = lastClient.Key.PassportId
        };

        // Act

        var account = dict[client];

        // Assert
        Assert.NotNull(account);
    }

    [Fact]
    public void AddClientsAccounts_WhenClientHasMultipleAccounts_ShouldReturnAllAccounts()
    {
        // Arrange
        var clientStorage = new ClientStorage();
        var clientService = new ClientService(clientStorage);

        var client = new Client
        {
            FirstName = "Stepan",
            LastName = "Golub",
            PhoneNumber = "+373",
            PassportId = "passId"
        };
        
        clientService.Add(client);

        clientService.AddAccount(client, new Account { Amount = 10000, Currency = new Currency { Code = "USD", Name = "Dollar" } });
        clientService.AddAccount(client, new Account { Amount = 15000, Currency = new Currency { Code = "RUB", Name = "Ruble" } });
        clientService.AddAccount(client, new Account { Amount = 20000, Currency = new Currency { Code = "EUR", Name = "Euro" } });

        // Act
        var accounts = clientService.GetAccounts(client);

        // Assert
        Assert.Equal(4, accounts.Count);
    }

    [Fact]
    public void Contains_WhenObjectInList_ShouldBeTrue()
    {
        // Arrange
        var list = TestDataGenerator.GenerateEmployeesList(100);

        var emp = list[Random.Next(list.Count)];

        var newEmp = new Employee
        {
            FirstName = emp.FirstName,
            LastName = emp.LastName,
            BirthDay = emp.BirthDay,
            PhoneNumber = emp.PhoneNumber,
            Salary = emp.Salary,
            PassportId = emp.PassportId
        };

        // Act
        var empFounded = list.Contains(newEmp);

        // Assert
        Assert.True(empFounded);
    }

    [Fact]
    public void Distinct_WhenSameObjectsInList_ListShouldBeUnique()
    {
        // Arrange
        var list = new List<Client>
        {
            new() { FirstName = "Stepan", LastName = "Golub", PhoneNumber = "+373", PassportId = "sameId"},
            new() { FirstName = "Stepan", LastName = "Golub", PhoneNumber = "+373", PassportId = "sameId"}
        };


        // Act
        // Distinct() использует под капотом Equals()
        var distinctPeople = list.Distinct().Count();

        // Assert
        Assert.Equal(1, distinctPeople);
    }
}