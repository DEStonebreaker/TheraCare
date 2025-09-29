using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;
using Library.TheraCare.Services.Repositories;

namespace Library.TheraCare.Services.Proxies;

public class PhysicianProxy
{
    private static PhysicianProxy? _instance;
    private static readonly object InstanceLock = new object();
    private readonly PhysicianRepository _physicianRepository;

    private PhysicianProxy(PhysicianRepository physicianRepository)
    {
        _physicianRepository = physicianRepository;
    }

    public static PhysicianProxy Current
    {
        get
        {
            lock (InstanceLock)
            {
                _instance ??= new PhysicianProxy(new PhysicianRepository());
            }

            return _instance;
        }
    }

    public IEnumerable<Physician?> Physicians => _physicianRepository.GetAll();

    public Physician CreatePhysician()
    {
        Physician physician = PhysicianFactory.FromCli();
        _physicianRepository.Create(physician);
        return physician;
    }

    public Physician? GetPhysician(Guid id)
    {
        Physician? physician = _physicianRepository.GetById(id);
        if (physician == null)
        {
            throw new ArgumentNullException(nameof(physician));
        }
        return physician;
    }

    public void DisplayPhysicians()
    {
        _physicianRepository.Display();
    }

    public bool UpdatePhysician(Guid id)
    {
        var physician = _physicianRepository.GetById(id);
        if (physician == null)
        {
            throw new ArgumentNullException(nameof(physician));
        }
        Physician newPhysician =  PhysicianFactory.PhysicianUpdater(physician);
        _physicianRepository.Update(newPhysician);
        
        return true;
    }

    public void DeletePhysician(Guid id)
    {
        _physicianRepository.Delete(id);
    }
}