namespace BankSystem.Domain;

public struct Currency
{
    public string Code { get; set; }
    public string Name { get; set; }

    public string GetInfo()
        => $"{Code} | {Name}";
}