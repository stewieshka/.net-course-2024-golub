using BankSystem.Domain;

namespace BankSystem.App.Services;

public static class BankService
{
    private static readonly List<Person> BlackList = [];

    public static int CalculateSalary(int profit, int expenses, int amount)
        => (profit - expenses) / amount;

    public static Employee Promote(Client client)
    {
        return new Employee
        {
            BirthDay = client.BirthDay,
            FirstName = client.FirstName,
            LastName = client.LastName,
            MiddleName = client.MiddleName
        };
    }

    public static void AddBonus<T>(T person)
        where T : Client
    {
        person.BonusCount++;
    }

    public static void AddToBlackList<T>(T person)
        where T : Person
    {
        BlackList.Add(person);
    }

    public static bool IsPersonInBlackList<T>(T person)
        where T : Person
    {
        return BlackList.Contains(person);
    }
}