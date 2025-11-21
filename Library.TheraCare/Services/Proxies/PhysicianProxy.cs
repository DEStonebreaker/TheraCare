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
        var PhysicianResponse = new WebRequestHandler().Get("/Physician").Result;
        if (PhysicianResponse != null)
        {
            _physicians = JsonConvert.DeserializeObject<List<Physician>>(PhysicianResponse) ?? new List<Physician?>();
        }
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
                var GetResponse = new WebRequestHandler().Get("/Physician").Result;
                if (GetResponse != null)
                {
                    _physicians = JsonConvert.DeserializeObject<List<Physician>>(GetResponse) ?? new List<Physician>();
                }

                return _physicians.ToList();
            }
        }
    }

    public Physician CreatePhysician(Physician physician)
    {
        lock (_lock)
        {
            // Physician physician = PhysicianFactory.FromCli();
            // _physicians.Add(physician);
            // return physician;

            var PostRequest = new WebRequestHandler().Post("/Physician",physician);
            if (PostRequest != null)
            {
                _physicians.Add(physician);
            }

            return physician;
        }
    }

    public ObservableCollection<Physician> GetPhysicians()
    {
        return new ObservableCollection<Physician>(_physicians);
    }

    public async Task<Physician?> GetPhysician(Guid id)
    {
        // return _physicians.FirstOrDefault(p => p.Id == id);
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
            int index = _physicians.FindIndex(p => p.Id == physician.Id);
            if (index != -1)
            {
                _physicians[index] = physician;
                return true;
            }
        }

        return false;
    }

    public async Task<bool> DeletePhysician(Guid id)
    {
        var response = await new WebRequestHandler().Delete($"/Physician/{id}");
        if (response != null)
        {
            int index = _physicians.FindIndex(p => p.Id == id);
            if (index != -1)
            {
                _physicians.RemoveAt(index);
                return true;
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