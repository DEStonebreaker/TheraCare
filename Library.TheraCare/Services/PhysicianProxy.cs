using Library.TheraCare.Models;

namespace Library.TheraCare.Services;

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

    public Physician AddPhysician()
    {
        Physician physician = PhysicianFactory.FromCli();
        lock (InstanceLock)
        {
            _physicianList.Add(physician);
        }

        return physician;
    }
}