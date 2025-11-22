using System.Collections.ObjectModel;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;
using Library.TheraCare.Utilities;
using Newtonsoft.Json;

namespace Library.TheraCare.Services.Proxies;

public class PhysicianProxy
{
    private static PhysicianProxy? _instance;
    private static readonly object _lock = new object();
    private List<Physician?> _physicians = new List<Physician>();

    private PhysicianProxy()
    {
        // Initialize with empty list - load data lazily
        _physicians = new List<Physician?>();
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

    public async Task<IEnumerable<Physician>> GetPhysiciansAsync()
    {
        var GetResponse = await new WebRequestHandler().Get("/Physician");
        if (GetResponse != null)
        {
            lock (_lock)
            {
                _physicians = JsonConvert.DeserializeObject<List<Physician>>(GetResponse) ?? new List<Physician>();
            }
        }

        lock (_lock)
        {
            return _physicians.ToList();
        }
    }

    public async Task<Physician> CreatePhysicianAsync(Physician physician)
    {
        var PostRequest = await new WebRequestHandler().Post("/Physician", physician);
        if (PostRequest != null)
        {
            lock (_lock)
            {
                _physicians.Add(physician);
            }
        }

        return physician;
    }

    public ObservableCollection<Physician> GetPhysicians()
    {
        lock (_lock)
        {
            return new ObservableCollection<Physician>(_physicians);
        }
    }

    public async Task<Physician?> GetPhysician(Guid id)
    {
        try
        {
            var GetRequest = await new WebRequestHandler().Get("/Physician/" + id);
            if (GetRequest != null)
            {
                return JsonConvert.DeserializeObject<Physician>(GetRequest);
            }
        }
        catch (Exception e)
        {
        }

        return null;
    }

    public async Task<bool> UpdatePhysician(Physician physician)
    {
        var response = await new WebRequestHandler().Put($"/Physician/{physician.Id}", physician);
        if (response != null)
        {
            lock (_lock)
            {
                int index = _physicians.FindIndex(p => p.Id == physician.Id);
                if (index != -1)
                {
                    _physicians[index] = physician;
                    return true;
                }
            }
        }

        return false;
    }

    public async Task<bool> DeletePhysician(Guid id)
    {
        var response = await new WebRequestHandler().Delete($"/Physician/{id}");
        if (response != null)
        {
            lock (_lock)
            {
                int index = _physicians.FindIndex(p => p.Id == id);
                if (index != -1)
                {
                    _physicians.RemoveAt(index);
                    return true;
                }
            }
        }

        return false;
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