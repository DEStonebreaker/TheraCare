using Library.TheraCare.Services;
namespace Library.TheraCare.Models;

public class Physician
{
        string? FirstName { get; set; }
    string? LastName { get; set; }

    public string? lastName
    {
        get
        {
            if (LastName == null)
                return "NA";
            return LastName;
        }
    }

    string? LicenseNumber { get; set; }
    string? GraduationDate { get; set; }
    string? Specializations { get; set; }

    private List<List<Tools.Appointment>> _appointments = Tools.BuildWeekSchedule();

    public void ScheduleInfo()
    {
        // IEnumerable<Tools.Appointment> appointments = daySchedule.Where(LName == LastName);
        Console.WriteLine($"\n=== Dr.{LastName}, Schedule Info ===\n");
        for (int i = 0, k = 0; i < 5; ++i)
        {
            Console.WriteLine($"Day {i + 1} Availability");
            foreach (var n in _appointments[i])
            {
                if (n.IsBooked)
                {
                    Console.Write($"| XX |");
                }
                else
                {
                    Console.Write($"|{n.StartTime.TimeOfDay.ToString()}|");
                }

                ++k;
                if (k % 6 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\n");
        }
    }

    public void BuildPhysician()
    {
        Console.Write("Enter the first name of the physician\n>> ");
        this.FirstName = Console.ReadLine();

        Console.Write("Enter the last name of the physician\n>> ");
        this.LastName = Console.ReadLine();

        Console.Write("Enter the license number of the physician\n>> ");
        this.LicenseNumber = Console.ReadLine();

        Console.Write("Enter the graduation date of the physician\n>> ");
        this.GraduationDate = Console.ReadLine();

        Console.Write("Enter the specializations of the physician\n>> ");
        this.Specializations = Console.ReadLine();
    }
    public bool AddAppointment(int dayIdx, TimeSpan time, string? notes = null)
    {
        if (dayIdx < 0 || dayIdx > 4) return false;
        if (_appointments == null) return false;

        var daySchedule = _appointments[dayIdx];
        var slot = daySchedule.FirstOrDefault(a => a.StartTime.TimeOfDay == time);
        if (slot == null || slot.IsBooked) return false;

        slot.IsBooked = true;
        slot.Notes = notes;

        return true;
    }
}