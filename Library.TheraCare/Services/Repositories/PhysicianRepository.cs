using Library.TheraCare.Models;

namespace Library.TheraCare.Services.Repositories;

public class PhysicianRepository : IRepository<Physician>
{
    private readonly List<Physician?> _physicians = new List<Physician?>();
    private static readonly object InstanceLock = new object();

    public Physician Create(Physician physician)
    {
        lock (InstanceLock)
        {
            _physicians.Add(physician);
            return physician;
        }
    }

    public Physician Update(Physician physician)
    {
        lock (InstanceLock)
        {
            int index = _physicians.FindIndex(p => p?.Id == p.Id);
            if (index != -1)
            {
                _physicians[index] = physician;
                return physician;
            }
        }
        return physician;
    }

    public Physician GetById(Guid id)
    {
        lock (InstanceLock)
        {
            Physician? physician = _physicians.FirstOrDefault(p => p?.Id == id);
            return physician;
        }
    }

    public IEnumerable<Physician?> GetAll()
    {
        lock (InstanceLock)
        {
            return _physicians;
        }
    }

    public void Delete(Guid id)
    {
        lock (InstanceLock)
        {
            int index = _physicians.FindIndex(p => p?.Id == id);
            if (index != -1)
            {
                _physicians.RemoveAt(index);
            }
        }
    }

    public void Display()
    {
        lock (InstanceLock)
        {
            foreach (var physician in _physicians)
            {
                Console.WriteLine($"{physician?.Id}: {physician?.LastName}, {physician?.FirstName}");
            }
        }
    }
}