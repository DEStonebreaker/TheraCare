using Library.TheraCare.Models;

namespace Library.TheraCare.Services;

public static class Tools
{
    public static string StrNormalize(string? input)
    {
        return input?.Trim() ?? "n/a";
    }

    // static public List<Appointment> BuildDaySchedule()
    // {
    //     DateTime startTime =
    //         new DateTime(2025, 01, 6, 8, 0, 0);
    //     DateTime endTime = startTime.AddHours(9);
    //
    //     List<Appointment> appointments = new List<Appointment>();
    //     for (var i = startTime; i < endTime; i = i.AddMinutes(30))
    //     {
    //         Appointment appointment = new Appointment();
    //         appointment.StartTime = i;
    //         appointment.IsBooked = false;
    //         appointments.Add(appointment);
    //     }
    //
    //     return appointments;
    // }

    // static public List<List<Appointment>> BuildWeekSchedule()
    // {
    //     List<List<Appointment>> weekSchedule = new List<List<Appointment>>();
    //     for (int i = 0; i < 5; ++i)
    //     {
    //         var appointments = BuildDaySchedule();
    //         weekSchedule.Add(appointments);
    //     }
    //
    //     return weekSchedule;
    // }
}