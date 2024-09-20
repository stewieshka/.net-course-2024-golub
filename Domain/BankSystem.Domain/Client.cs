namespace BankSystem.Domain;

/// <summary>
/// Модель, описывающая сущность клиента
/// </summary>
public class Client : Person
{
    // Для Bogus
    public Client() {}
    
    public Client(DateOnly birthDay, string phoneNumber, string firstName, string lastName, string? middleName = null) 
        : base(birthDay, phoneNumber, firstName, lastName, middleName) {}
}