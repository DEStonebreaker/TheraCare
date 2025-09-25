using Library.TheraCare.Models;

namespace Library.TheraCare.Services.Repositories;

public interface IRepository<T>
{
    T Create(T entity);
    T Update(T entity);
    T GetById(Guid id);
    IEnumerable<T?> GetAll();
    void Delete(Guid id);
}