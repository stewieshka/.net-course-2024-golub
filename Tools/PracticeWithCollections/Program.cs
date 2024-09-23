using System.Diagnostics;
using BankSystem.App.Services;
using BankSystem.Domain;

namespace PracticeWithCollections;

public static class Program
{
    private static readonly List<Client> ClientsList = TestDataGenerator.GenerateClientsList(1000);
    private static readonly List<Employee> EmployeesList = TestDataGenerator.GenerateEmployeesList(1000);
    private static readonly Dictionary<string, Client> ClientsDict = TestDataGenerator.GenerateClientsDictionary(1000);

    private static readonly Stopwatch Stopwatch = new();
    
    public static void Main()
    {
        Measure(ListFind, "Поиск в списке");
        Measure(ClientsWhereAgeBelow, "Выбор элементов из списка с возрастом меньше 35");
        Measure(EmployeesMinimumSalary, "Поиск сотрудника с минимальной зарплатой");
        Measure(DictionarySearchByKey, "Поиск в словаре по ключу");
        Measure(ClientsDictLastOrDefault, "Поиск последнего в словаре через LastOrDefault");
    }

    private static void Measure(Action action, string text)
    {
        Console.WriteLine(text);
        Stopwatch.Reset();
        
        Stopwatch.Start();

        action();
        
        Stopwatch.Stop();

        Console.WriteLine($"Потрачено: {Stopwatch.ElapsedTicks} тиков");
    }

    private static void ListFind()
    {
        var lastClient = ClientsList.LastOrDefault()!;

        var foundedClient = ClientsList.Find(x => x.PhoneNumber == lastClient.PhoneNumber);
    }

    private static void DictionarySearchByKey()
    {
        var lastClient = ClientsDict.LastOrDefault()!;

        var foundedClient = ClientsDict[lastClient.Key];
    }

    private static void ClientsWhereAgeBelow()
    {
        var foundedClients = ClientsList.Where(x => x.CalculateAge() < 35).ToList();
    }

    private static void EmployeesMinimumSalary()
    {
        var employeeWithMinSalary = EmployeesList.MinBy(x => x.Salary);
    }

    private static void ClientsDictLastOrDefault()
    {
        var last = ClientsDict.LastOrDefault();
    }
}