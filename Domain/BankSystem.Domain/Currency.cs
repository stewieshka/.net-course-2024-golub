namespace BankSystem.Domain;

public class Currency
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    
    public ICollection<Account> Accounts { get; set; }

    public string GetInfo()
        => $"{Code} | {Name}";
}