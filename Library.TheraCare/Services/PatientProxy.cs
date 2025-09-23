using Library.TheraCare.Models;

namespace Library.TheraCare.Services;

public class PatientProxy
{
    private List<Patient?> _patients;

    private PatientProxy()
    {
        _patients = new List<Patient?>();
    }

    private static PatientProxy? _instance;
    private static object _instanceLock = new object();

    public static PatientProxy Current
    {
        get
        {
            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new PatientProxy();
                }
            }

            return _instance;
        }
    }

    public List<Patient?> Patients
    {
        get
        {
            return _patients;
        }
    }

    public Patient AddPatient()
    {
        Patient patient = PatientFactory.FromCli();
        return patient;
    }

}