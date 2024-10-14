namespace BankSystem.Domain;

public class Client : Person
{
    public int BonusAmount = 0;
    
    public ICollection<Account> Accounts { get; set; }
}