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
        
        ExportService.ExportCsv<Client>(25, fileName);

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
        ExportService.ImportCsv<Client>(fileName);

        var list = context.Clients
            .Take(25)
            .ToList();

        // Assert
        Assert.True(list.Count != 0);
    }
}