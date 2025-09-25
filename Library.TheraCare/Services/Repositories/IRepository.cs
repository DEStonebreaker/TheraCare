using Library.TheraCare.Models;

namespace Library.TheraCare.Services.Repositories;

public interface IRepository<T>
{
    T Create(T entity);
    T Update(T entity);
    Patient GetById(Guid id);
    IEnumerable<Patient?> GetAll();
    void Delete(Guid id);
}