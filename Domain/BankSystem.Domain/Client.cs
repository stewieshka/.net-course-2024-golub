namespace BankSystem.Domain;

/// <summary>
/// Модель, описывающая сущность клиента
/// </summary>
public class Client : Person
{
    public Client(DateOnly birthDay, string firstName, string lastName, string? middleName = null) 
        : base(birthDay, firstName, lastName, middleName) {}
}