using BankSystem.App.Services;
using BankSystem.Domain;

namespace BankSystem.Data.Tests;

public class PeopleStorageTests
{
    [Fact]
    public void MyMinBy_ShouldReturnYoungestClient_WhenCalled()
    {
        // Arrange
        var clientStorage = new ClientStorageDb();

        var clientList = TestDataGenerator.GenerateClientsList(100);

        foreach (var client in clientList)
        {
            clientStorage.Add(client);
        }

        var actualYoungest = clientList.MinBy(x => x.CalculateAge());

        // Act
        var youngest = clientStorage.MinBy(x => x.CalculateAge());

        // Assert
        Assert.Equal(actualYoungest, youngest);
    }
    
    [Fact]
    public void MyMaxBy_ShouldReturnOldestClient_WhenCalled()
    {
        // Arrange
        var clientStorage = new ClientStorageDb();

        var clientList = TestDataGenerator.GenerateClientsList(100);

        foreach (var client in clientList)
        {
            clientStorage.Add(client);
        }

        var actualOldest = clientList.MaxBy(x => x.CalculateAge());

        // Act
        var oldest = clientStorage.MaxBy(x => x.CalculateAge());

        // Assert
        Assert.Equal(actualOldest, oldest);
    }
    
    [Fact]
    public void MyAverage_ShouldReturnAverageAge_WhenCalled()
    {
        // Arrange
        var clientStorage = new ClientStorageDb();

        var clientList = TestDataGenerator.GenerateClientsList(100);

        foreach (var client in clientList)
        {
            clientStorage.Add(client);
        }

        var actualAverage = clientList.Average(x => x.CalculateAge());

        // Act
        var average = clientStorage.Average(x => x.CalculateAge());

        // Assert
        Assert.Equal(actualAverage, average);
    }
}