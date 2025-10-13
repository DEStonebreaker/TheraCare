using Library.TheraCare.Models;

namespace Library.TheraCare.Services.Factories;

public static class FromArgs
{
    public static Appointment ApptFromArgs(Physician inPhysician, Patient inPatient, DateTime inStartTime, TimeSpan? inDuration, bool  inIsBooked, string? inNotes)
    {
        return new Appointment
        {
            Physician = inPhysician,
            Patient = inPatient,
            StartTime = inStartTime,
            Duration = inDuration,
            IsBooked = inIsBooked,
            Notes = inNotes,
        };
    }
}