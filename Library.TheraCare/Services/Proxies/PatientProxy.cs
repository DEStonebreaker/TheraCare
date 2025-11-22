using System.Collections.ObjectModel;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;
using Library.TheraCare.Utilities;
using Newtonsoft.Json;

namespace Library.TheraCare.Services.Proxies;

public class PatientProxy
{
    private static PatientProxy? _instance;
    private static readonly object _lock = new object();
    private List<Patient?> _patients = new List<Patient?>();

    private PatientProxy()
    {
        // Initialize with empty list - load data lazily
        _patients = new List<Patient?>();
    }

    public static PatientProxy Current
    {
        get
        {
            lock (_lock)
            {
                _instance ??= new PatientProxy();
            }

            return _instance;
        }
    }

    public async Task<IEnumerable<Patient>> GetPatientsAsync()
    {
        var GetResponse = await new WebRequestHandler().Get("/Patient");
        if (GetResponse != null)
        {
            lock (_lock)
            {
                _patients = JsonConvert.DeserializeObject<List<Patient>>(GetResponse) ?? new List<Patient>();
            }
        }

        lock (_lock)
        {
            return _patients.ToList();
        }
    }

    public async Task<Patient> CreatePatientAsync(Patient patient)
    {
        var PostRequest = await new WebRequestHandler().Post("/Patient", patient);
        if (PostRequest != null)
        {
            lock (_lock)
            {
                _patients.Add(patient);
            }
        }

        return patient;
    }

    public async Task<Patient?> GetPatient(Guid id)
    {
        try
        {
            var GetRequest = await new WebRequestHandler().Get("/Patient/" + id);
            if (GetRequest != null)
            {
                return JsonConvert.DeserializeObject<Patient>(GetRequest);
            }
        }
        catch (Exception e)
        {
        }

        return null;
    }

    public ObservableCollection<Patient> GetPatients()
    {
        lock (_lock)
        {
            return new ObservableCollection<Patient>(_patients);
        }
    }

    public async Task<bool> UpdatePatient(Patient patient)
    {
        var response = await new WebRequestHandler().Put($"/Patient/{patient.Id}", patient);
        if (response != null)
        {
            lock (_lock)
            {
                int index = _patients.FindIndex(p => p.Id == patient.Id);
                if (index != -1)
                {
                    _patients[index] = patient;
                    return true;
                }
            }
        }

        return false;
    }

    public async Task<bool> DeletePatient(Guid id)
    {
        var response = await new WebRequestHandler().Delete($"/Patient/{id}");
        if (response != null)
        {
            lock (_lock)
            {
                int index = _patients.FindIndex(p => p.Id == id);
                if (index != -1)
                {
                    _patients.RemoveAt(index);
                    return true;
                }
            }
        }

        return false;
    }

    public void DisplayPatients()
    {
        lock (_lock)
        {
            foreach (var patient in _patients)
            {
                Console.WriteLine($"{patient.Id}: {patient.LastName}, {patient.FirstName}");
            }
        }
    }
}