using BankSystem.App.Exceptions;
using BankSystem.App.Services;
using BankSystem.Data;
using BankSystem.Domain;

namespace BankSystem.App.Tests;

public class PeopleServiceTests
{
    [Fact]
    public void AddClient_ShouldThrowLowAgeException_WhenClientIsUnderage()
    {
        // Arrange
        var clientStorage = new PeopleStorage<Client>();
        var clientService = new PeopleService<Client>(clientStorage);
        var client = new Client
        {
            BirthDay = new DateOnly(2010, 1, 1),
            PassportId = "id"
        };

        // Act & Assert
        Assert.Throws<LowAgeException>(() => clientService.Add(client));
    }

    [Fact]
    public void AddClient_ShouldThrowMyValidationException_WhenPassportIdIsNullOrEmpty()
    {
        // Arrange
        var clientStorage = new PeopleStorage<Client>();
        var clientService = new PeopleService<Client>(clientStorage);
        var client = new Client
        {
            BirthDay = new DateOnly(2000, 1, 1)
        };

        // Act & Assert
        Assert.Throws<MyValidationException>(() => clientService.Add(client));
    }

    [Fact]
    public void AddClient_ShouldAddClient_WhenClientIsValid()
    {
        // Arrange
        var clientStorage = new PeopleStorage<Client>();
        var clientService = new PeopleService<Client>(clientStorage);
        var client = new Client
        {
            BirthDay = new DateOnly(2000, 1, 1),
            PassportId = "id"
        };

        // Act
        clientService.Add(client);

        // Assert
        Assert.Equal(1, clientStorage.Count());
    }

    [Fact]
    public void AddAccount_ShouldThrowMyValidationException_WhenCurrencyCodeIsEmpty()
    {
        // Arrange
        var clientStorage = new PeopleStorage<Client>();
        var clientService = new PeopleService<Client>(clientStorage);
        var client = new Client
        {
            BirthDay = new DateOnly(2000, 1, 1),
            PassportId = "id"
        };

        clientService.Add(client);

        var account = new Account
        {
            Currency = new Currency
            {
                Name = "Dollar"
            }
        };

        // Act & Assert
        Assert.Throws<MyValidationException>(() => clientService.AddAccount(client, account));
    }

    [Fact]
    public void AddAccount_ShouldThrowMyValidationException_WhenCurrencyNameIsEmpty()
    {
        // Arrange
        var clientStorage = new PeopleStorage<Client>();
        var clientService = new PeopleService<Client>(clientStorage);
        var client = new Client
        {
            BirthDay = new DateOnly(2000, 1, 1),
            PassportId = "id"
        };

        clientService.Add(client);

        var account = new Account
        {
            Currency = new Currency
            {
                Code = "USD"
            }
        };

        // Act & Assert
        Assert.Throws<MyValidationException>(() => clientService.AddAccount(client, account));
    }

    [Fact]
    public void AddAccount_ShouldAddAccount_WhenValidAccountProvided()
    {
        // Arrange
        var clientStorage = new PeopleStorage<Client>();
        var clientService = new PeopleService<Client>(clientStorage);
        var client = new Client
        {
            BirthDay = new DateOnly(2000, 1, 1),
            PassportId = "id"
        };

        clientService.Add(client);

        var account = new Account
        {
            Currency = new Currency
            {
                Code = "EUR",
                Name = "Euro"
            }
        };

        // Act
        clientService.AddAccount(client, account);

        // Assert
        Assert.Equal(2, clientService.GetAccounts(client).Count);
    }

    [Fact]
    public void DeleteAccount_ShouldRemoveAccount_WhenAccountExists()
    {
        // Arrange
        var clientStorage = new PeopleStorage<Client>();
        var clientService = new PeopleService<Client>(clientStorage);
        var client = new Client
        {
            BirthDay = new DateOnly(2000, 1, 1),
            PassportId = "id"
        };

        clientService.Add(client);

        var account = new Account
        {
            Currency = new Currency
            {
                Code = "USD",
                Name = "Dollar"
            },
            Amount = 100
        };

        clientService.AddAccount(client, account);

        // Act
        clientService.DeleteAccount(client, account);

        // Assert
        Assert.Single(clientService.GetAccounts(client));
    }

    [Fact]
    public void UpdateAccount_ShouldUpdateAccount_WhenValidDataProvided()
    {
        // Arrange
        var clientStorage = new PeopleStorage<Client>();
        var clientService = new PeopleService<Client>(clientStorage);
        var client = new Client
        {
            BirthDay = new DateOnly(2000, 1, 1),
            PassportId = "id"
        };

        clientService.Add(client);

        var account = clientService.GetAccounts(client).First();
        var currency = new Currency { Code = "RUB", Name = "Ruble" };

        // Act
        clientService.Update(account, 10000, currency);
        
        // Assert
        Assert.True(account.Amount == 10000 && account.Currency.Equals(currency));
    }

    [Fact]
    public void GetByQuery_ShouldReturnFilteredClients_WhenFiltersAreApplied()
    {
        // Arrange
        var clientStorage = new PeopleStorage<Client>();
        var clientService = new PeopleService<Client>(clientStorage);
        
        clientService.Add(new Client
        {
            PassportId = "id",
            BirthDay = new DateOnly(2001, 1, 1),
            FirstName = "Stepan",
            LastName = "Golub"
        });
        
        clientService.Add(new Client
        {
            PassportId = "id",
            BirthDay = new DateOnly(2000, 1, 1),
            FirstName = "Stepan"
        });
        
        clientService.Add(new Client
        {
            PassportId = "id",
            BirthDay = new DateOnly(2000, 1, 1),
            FirstName = "Alex"
        });
        
        // Act
        var count = clientService.GetByQuery(firstName: "Stepan").Count;
        
        // Assert
        Assert.Equal(2, count);
    }
}
