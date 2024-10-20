using System.Globalization;
using CsvHelper;

namespace ExportTool;

public static class ExportService
{
    public static void ExportCsv<T>(IList<T> list, string fileName)
        where T : class
    {
        var path = Path.Combine(Environment.CurrentDirectory, fileName);

        using var streamWriter = new StreamWriter(path);

        using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

        csvWriter.WriteRecords(list);
    }

    public static List<T> ImportCsv<T>(string fileName)
        where T : class
    {
        var path = Path.Combine(Environment.CurrentDirectory, fileName);

        using var streamReader = new StreamReader(path);

        using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

        var list = csvReader.GetRecords<T>().ToList();

        return list;
    }
}