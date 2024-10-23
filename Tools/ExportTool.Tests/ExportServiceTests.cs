using BankSystem.App.Services;
using BankSystem.Data;
using BankSystem.Domain;

namespace ExportTool.Tests;

public class ExportServiceTests
{
    [Fact]
    public void ExportCsv_ShouldCreateCsvFileWithClients_WhenCalled()
    {
        // Act
        using var context = new BankSystemDbContext();

        var randomClientsList = TestDataGenerator.GenerateClientsList(25);
        
        context.Clients.AddRange(randomClientsList);

        context.SaveChanges();

        const string fileName = "test1.csv";
        
        // Arrange
        ExportService.ExportCsv(context.Clients.Take(25).ToArray(), Path.Combine(Environment.CurrentDirectory, fileName));
        
        using var streamReader = new StreamReader(
            Path.Combine(Environment.CurrentDirectory, fileName));

        var content = streamReader.ReadToEnd();

        // Assert
        Assert.True(content.Length != 0);
    }

    [Fact]
    public void ImportCsv_ShouldReadClientsFromCsvFile_WhenCalled()
    {
        // Act
        using var context = new BankSystemDbContext();
        
        const string fileName = "test1.csv";
        
        // Arrange
        var list = ExportService.ImportCsv<Client>(
            Path.Combine(Environment.CurrentDirectory, fileName));

        context.Clients.AddRange(list);

        context.SaveChanges();
        
        // Assert
        Assert.True(context.Clients.Count() == 25);
    }
    
    [Fact]
    public void ExportJson_ShouldCreateJsonFileWithClients_WhenCalled()
    {
        // Act
        var clients = TestDataGenerator.GenerateClientsList(10);
        
        var filePath = Path.Combine(Environment.CurrentDirectory, "test1.json");
        
        // Arrange
        ExportService.ExportJson(clients, filePath);
        
        // Assert
        Assert.True(File.ReadAllText(filePath).Length > 0);
    }

    [Fact]
    public void ImportJson_ShouldDeserializeClientsJsonFile_WhenCalled()
    {
        // Act
        var filePath = Path.Combine(Environment.CurrentDirectory, "test1.json");
        
        // Arrange

        var clients = ExportService.ImportJson<Client>(filePath);

        // Assert
        Assert.True(clients.Count == 10);
    }
}