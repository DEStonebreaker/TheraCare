using Library.TheraCare.Models;

namespace Library.TheraCare.Services.Factories;

public static class AppointmentFactory
{
    public static Appointment ApptFromArgs(Physician inPhysician, Patient inPatient, DateTime? inTime, bool  inIsBooked, string? inNotes)
    {
        return new Appointment
        {
            Id = Guid.NewGuid(),
            Physician = inPhysician,
            Patient = inPatient,
            StartTime = inTime,
            IsBooked = inIsBooked,
            Notes = inNotes,
        };
    }
}