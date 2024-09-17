using BankSystem.Domain;

namespace Services;

public static class BankService
{
    public static int CalculateSalary(int profit, int expenses, int amount)
        => (profit - expenses) / amount;

    public static Employee Promote(Client client)
    {
        // Закомментированное решение вызывает исключение
        
        // Person person = client;
        //
        // Employee employee = (Employee)person;
        //
        // return employee;
        
        return new Employee(client.BirthDay, client.FirstName, client.LastName, client.MiddleName);
    }
}