using BankSystem.App.Services;
using BankSystem.Domain;

namespace BankSystem.App.Tests;

public class EquivalenceTests
{
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
            PhoneNumber = lastClient.Key.PhoneNumber
        };

        // Act

        var acount = dict[client];

        // Assert
        Assert.NotNull(acount);
    }

    [Fact]
    public void AddClientsAccounts_WhenClientHasMultipleAccounts_ShouldReturnAllAccounts()
    {
        // Arrange
        var dict = new Dictionary<Client, List<Account>>();

        var client = new Client
        {
            FirstName = "Stepan",
            LastName = "Golub",
            PhoneNumber = "+373"
        };

        dict.Add(client, []);

        var accountList = dict[client];
        
        accountList.Add(new Account {Amount = 10000, Currency = "USD"});
        accountList.Add(new Account {Amount = 15000, Currency = "RUB"});
        accountList.Add(new Account {Amount = 20000, Currency = "EUR"});
        
        // Act
        var accounts = dict[client];

        // Assert
        Assert.Equal(3, accounts.Count);
    }

    [Fact]
    public void Contains_WhenObjectInList_ShouldBeTrue()
    {
        // Arrange
        var list = TestDataGenerator.GenerateEmployeesList(100);

        var emp = list[57];

        // Act
        var empFounded = list.Contains(emp);

        // Assert
        Assert.True(empFounded);
    }

    [Fact]
    public void Distinct_WhenSameObjectsInList_ListShouldBeUnique()
    {
        // Arrange
        var list = new List<Client>
        {
            new() { FirstName = "Stepan", LastName = "Golub", PhoneNumber = "+373"},
            new() { FirstName = "Stepan", LastName = "Golub", PhoneNumber = "+373"}
        };


        // Act
        // Distinct() использует под капотом Equals()
        var distinctPeople = list.Distinct().Count();

        // Assert
        Assert.Equal(1, distinctPeople);
    }
}