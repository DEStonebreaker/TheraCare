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
        var PatientResponse = new WebRequestHandler().Get("/Patient").Result;
        if (PatientResponse != null)
        {
            _patients = JsonConvert.DeserializeObject<List<Patient?>>(PatientResponse) ?? new List<Patient?>();
        }
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

    public IEnumerable<Patient> Patients
    {
        get
        {
            lock (_lock)
            {
                var GetResponse = new WebRequestHandler().Get("/Patient").Result;
                if (GetResponse != null)
                {
                    _patients = JsonConvert.DeserializeObject<List<Patient>>(GetResponse) ?? new List<Patient>();
                }

                return _patients.ToList();
            }
        }
    }

    public Patient CreatePatient(Patient patient)
    {
        lock (_lock)
        {
            // Patient patient = PatientFactory.FromCli();
            var PostRequest = new WebRequestHandler().Post("/Patient", patient);
            if (PostRequest != null)
            {
                _patients.Add(patient);
            }

            return patient;
        }
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
        return new ObservableCollection<Patient>(_patients);
    }

    public async Task<bool> UpdatePatient(Patient patient)
    {
        var response = await new WebRequestHandler().Put($"/Patient/{patient.Id}", patient);
        if (response != null)
        {
            int index = _patients.FindIndex(p => p.Id == patient.Id);
            if (index != -1)
            {
                _patients[index] = patient;
                return true;
            }
        }

        return false;
    }

    public bool DeletePatient(Guid id)
    {
        var response = new WebRequestHandler().Delete("/Patient/" + id).Result;
        if (response != null)
        {
            int index = _patients.FindIndex(p => p.Id == id);
            if (index != -1)
            {
                _patients.RemoveAt(index);
                return true;
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