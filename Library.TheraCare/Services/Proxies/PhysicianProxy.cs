using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;

namespace Library.TheraCare.Services.Proxies;

public class PhysicianProxy
{
    private readonly List<Physician?> _physicianList;

    private PhysicianProxy()
    {
        _physicianList = new List<Physician?>();
    }

    private static PhysicianProxy? _instance;
    private static readonly Lock InstanceLock = new Lock();

    public static PhysicianProxy Current
    {
        get
        {
            lock (InstanceLock)
            {
                _instance ??= new PhysicianProxy();
            }

            return _instance;
        }
    }

    public List<Physician?> Physicians => _physicianList;

    public Physician CreatePhysician()
    {
        Physician physician = PhysicianFactory.FromCli();
        lock (InstanceLock)
        {
            _physicianList.Add(physician);
        }

        return physician;
    }
}