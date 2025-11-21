using Api.TheraCare.Database;
using Library.TheraCare.Models;

namespace Api.TheraCare.Enterprise;

public class PhysicianEC
{
    public IEnumerable<Physician> GetPhysicians()
    {
        return FakeDatabase.Physicians;
    }

    public Physician? GetById(Guid id)
    {
        return FakeDatabase.Physicians.FirstOrDefault(p => p.Id == id);
    }

    public Physician? Post(Physician physician)
    {
        var state = GetById(physician.Id);
        if (state != null) return null;

        FakeDatabase.Physicians.Add(physician);
        return physician;
    }

    public Physician? Delete(Guid id)
    {
        var toRemove = GetById(id);
        if (toRemove != null)
        {
            FakeDatabase.Physicians.Remove(toRemove);
        }

        return toRemove;
    }

    public bool Put(Guid id, Physician physician)
    {
        var pati = FakeDatabase.Physicians.FirstOrDefault(p => p.Id == physician.Id);
        if (pati == null)
        {
            return false;
        }

        int index = FakeDatabase.Physicians.FindIndex(p => p.Id == physician.Id);
        if (index != -1)
        {
            FakeDatabase.Physicians[index] = physician;
            return true;
        }

        return false;
    }
}