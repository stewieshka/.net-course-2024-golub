using System.Linq.Expressions;
using BankSystem.Domain;

namespace BankSystem.App.Interfaces;

public interface IStorageDb<T>
{
    T GetById(Guid id);
    List<T> Get(int pageSize, int pageNumber, List<Expression<Func<T, bool>>> filters);
    void Add(T item);
    void Update(T item);
    void Delete(T item);
}