using System.Collections.ObjectModel;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;

namespace Library.TheraCare.Services.Proxies;

public class PhysicianProxy
{
    private static PhysicianProxy? _instance;
    private static readonly object _lock = new object();
    private readonly List<Physician> _physicians = new List<Physician>();

    private PhysicianProxy()
    {
    }

    public static PhysicianProxy Current
    {
        get
        {
            lock (_lock)
            {
                _instance ??= new PhysicianProxy();
            }

            return _instance;
        }
    }

    public IEnumerable<Physician> Physicians
    {
        get
        {
            lock (_lock)
            {
                return _physicians.ToList(); // Return a copy to prevent external modification
            }
        }
    }

    public Physician CreatePhysician(Physician physician)
    {
        lock (_lock)
        {
            // Physician physician = PhysicianFactory.FromCli();
            _physicians.Add(physician);
            return physician;
        }
    }

    public ObservableCollection<Physician> GetPhysicians()
    {
        return new ObservableCollection<Physician>(_physicians);
    }

    public Physician? GetPhysician(Guid id)
    {
        lock (_lock)
        {
            return _physicians.FirstOrDefault(p => p.Id == id);
        }
    }

    public bool UpdatePhysician(Physician physician)
    {
        lock (_lock)
        {
            var physician_l = _physicians.FirstOrDefault(p => p.Id == physician.Id);
            if (physician_l == null)
            {
                return false;
            }

            Physician updatedPhysician = physician_l;

            int index = _physicians.FindIndex(p => p.Id == physician.Id);
            if (index != -1)
            {
                _physicians[index] = updatedPhysician;
                return true;
            }

            return false;
        }
    }

    public bool DeletePhysician(Guid id)
    {
        lock (_lock)
        {
            int index = _physicians.FindIndex(p => p.Id == id);
            if (index != -1)
            {
                _physicians.RemoveAt(index);
                return true;
            }

            return false;
        }
    }

    public void DisplayPhysicians()
    {
        lock (_lock)
        {
            foreach (var physician in _physicians)
            {
                Console.WriteLine($"{physician.Id}: {physician.LastName}, {physician.FirstName}");
            }
        }
    }
}