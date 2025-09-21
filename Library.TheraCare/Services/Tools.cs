using Library.TheraCare.Models;
namespace Library.TheraCare.Services;

public class Tools
{
    public void ScheduleAppt(int start, int end)
    {
        // ScheduleInfo()
        // Prompt for day.
        // Prompt for Doctor. This should also show the doctor's availability for the day.
    }

    public class Appointment
    {
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; } = TimeSpan.FromMinutes(30);
        public bool IsBooked { get; set; } = false;
        public Physician? Physician { get; set; }
        // public Patient? Patient { get; set; }
        public string? Notes { get; set; }
    }

    static public List<Appointment> BuildDaySchedule()
    {
        DateTime startTime =
            new DateTime(2025, 01, 6, 8, 0, 0);
        DateTime endTime = startTime.AddHours(9);

        List<Appointment> appointments = new List<Appointment>();
        for (var i = startTime; i < endTime; i = i.AddMinutes(30))
        {
            Appointment appointment = new Appointment();
            appointment.StartTime = i;
            appointment.IsBooked = false;
            appointments.Add(appointment);
        }

        return appointments;
    }

    static public List<List<Appointment>> BuildWeekSchedule()
    {
        List<List<Appointment>> weekSchedule = new List<List<Appointment>>();
        for (int i = 0; i < 5; ++i)
        {
            var appointments = BuildDaySchedule();
            weekSchedule.Add(appointments);
        }

        return weekSchedule;
    }

    static public void PhysicianList(ref List<Physician> pl)
    {
        Console.WriteLine($"Physicians for the Week {pl.Count}");
        foreach (var p in pl)
        {
            Console.WriteLine($"{p.lastName}");
        }
    }
}