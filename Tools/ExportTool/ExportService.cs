using System.Globalization;
using BankSystem.Data;
using CsvHelper;

namespace ExportTool;

public static class ExportService
{
    public static void ExportCsv<T>(int limit, string fileName)
        where T : class
    {
        var path = Path.Combine(Environment.CurrentDirectory, fileName);

        using var context = new BankSystemDbContext();

        var list = context.Set<T>()
            .Take(limit)
            .ToList();

        using var streamWriter = new StreamWriter(path);

        using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

        csvWriter.WriteRecords(list);
    }

    public static void ImportCsv<T>(string fileName)
        where T : class
    {
        var path = Path.Combine(Environment.CurrentDirectory, fileName);

        using var streamReader = new StreamReader(path);

        using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

        var list = csvReader.GetRecords<T>().ToList();

        using var context = new BankSystemDbContext();

        context.Set<T>().AddRange(list);

        context.SaveChanges();
    }
}