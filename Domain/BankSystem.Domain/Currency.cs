namespace BankSystem.Domain;

public struct Currency(string code, string name)
{
    public string Code { get; set; } = code;
    public string Name { get; set; } = name;

    public string GetInfo()
        => $"{Code} | {Name}";
}