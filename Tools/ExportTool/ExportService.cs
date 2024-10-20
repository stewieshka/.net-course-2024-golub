using System.Globalization;
using CsvHelper;

namespace ExportTool;

public static class ExportService
{
    public static void ExportCsv<T>(IList<T> list, string filePath)
        where T : class
    {
        using var streamWriter = new StreamWriter(filePath);

        using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

        csvWriter.WriteRecords(list);
    }

    public static List<T> ImportCsv<T>(string filePath)
        where T : class
    {
        using var streamReader = new StreamReader(filePath);

        using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

        var list = csvReader.GetRecords<T>().ToList();

        return list;
    }
}