using BankSystem.Domain;

namespace Services;

public static class BankService
{
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
}