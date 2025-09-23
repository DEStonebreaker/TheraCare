namespace Library.TheraCare.Models;

public class Physician
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;

    public string LicenseNumber { get; init; } = string.Empty;
    public string GraduationDate { get; init; } = string.Empty;
    public string Specializations { get; init; } = string.Empty;

    private List<List<Appointment>> _Appointments = new();// Tools.BuildWeekSchedule();

    public bool AddAppointment(int dayIdx, TimeSpan time, string? notes = null)
    {
        if (dayIdx < 0 || dayIdx > 4) return false;
        // if (_Appointments == null) return false;

        var daySchedule = _Appointments[dayIdx];
        var slot = daySchedule.FirstOrDefault(a => a.StartTime.TimeOfDay == time);
        if (slot == null || slot.IsBooked) return false;

        slot.IsBooked = true;
        slot.Notes = notes;

        return true;
    }
}