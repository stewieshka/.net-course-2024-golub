
using BankSystem.Domain;

namespace BankSystem.App.Interfaces;

public interface IClientStorageDb : IStorageDb<Client>
{
    IReadOnlyList<Account> GetAccounts(Client client);
    void AddAccount(Client client, Account account);
    void UpdateAccount(Account item);
    void DeleteAccount(Account item);
}