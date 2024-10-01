using BankSystem.App.Services;
using BankSystem.Domain;

namespace BankSystem.Data.Tests;

public class PeopleStorageTests
{
    [Fact]
    public void MyMinBy_ShouldReturnYoungestClient_WhenCalled()
    {
        // Arrange
        var clientStorage = new PeopleStorage<Client>();

        var clientList = TestDataGenerator.GenerateClientsList(100);

        clientStorage.MyAddRange(clientList);

        var actualYoungest = clientList.MinBy(x => x.CalculateAge());

        // Act
        var youngest = clientStorage.MyMinBy(x => x.CalculateAge());

        // Assert
        Assert.Equal(actualYoungest, youngest);
    }
    
    [Fact]
    public void MyMaxBy_ShouldReturnOldestClient_WhenCalled()
    {
        // Arrange
        var clientStorage = new PeopleStorage<Client>();

        var clientList = TestDataGenerator.GenerateClientsList(100);

        clientStorage.MyAddRange(clientList);

        var actualOldest = clientList.MaxBy(x => x.CalculateAge());

        // Act
        var oldest = clientStorage.MyMaxBy(x => x.CalculateAge());

        // Assert
        Assert.Equal(actualOldest, oldest);
    }
    
    [Fact]
    public void MyAverage_ShouldReturnAverageAge_WhenCalled()
    {
        // Arrange
        var clientStorage = new PeopleStorage<Client>();

        var clientList = TestDataGenerator.GenerateClientsList(100);

        clientStorage.MyAddRange(clientList);

        var actualAverage = clientList.Average(x => x.CalculateAge());

        // Act
        var average = clientStorage.MyAverage(x => x.CalculateAge());

        // Assert
        Assert.Equal(actualAverage, average);
    }
}