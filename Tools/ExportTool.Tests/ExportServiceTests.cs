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
        ExportService.ExportCsv(context.Clients.Take(25).ToArray(), fileName);
        
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
        var list = ExportService.ImportCsv<Client>(fileName);

        context.Clients.AddRange(list);

        context.SaveChanges();
        
        // Assert
        Assert.True(context.Clients.Count() == 25);
    }
}