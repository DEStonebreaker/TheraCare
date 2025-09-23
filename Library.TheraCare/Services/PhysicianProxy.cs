using Library.TheraCare.Models;

namespace Library.TheraCare.Services;

public class PhysicianProxy
{
    private List<Physician?> _physicianList;

    private PhysicianProxy()
    {
        _physicianList = new List<Physician?>();
    }
    
    private static PhysicianProxy? _instance;
    private static object _instanceLock = new object();

    public static PhysicianProxy Current
    {
        get
        {
            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new PhysicianProxy();
                }
            }
            return _instance;
        }
    }

    public List<Physician?> Physicians
    {
        get { return _physicianList; }
    }

    public Physician AddPhysician()
    {
        Physician physician = PhysicianFactory.FromCli();
        return physician;
    }
}