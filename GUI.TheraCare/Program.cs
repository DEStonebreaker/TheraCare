using Library.TheraCare.Models;
using Library.TheraCare.Services;
namespace GUI.TheraCare;

    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Welcome to, CLITheraCare ===\n");
            // List<Patient> patients = new List<Patient>();
            List<Patient?> patients = PatientProxy.Current.Patients;
            List<Physician?> physicians = PhysicianProxy.Current.Physicians;
            // List<Physician> physicians = new List<Physician>();
            

            // List <List<Tools.Appointment>> weekAppointments = Tools.BuildWeekSchedule();

            bool cont = true;
            while (cont)
            {
                Console.WriteLine("1) Create Patient");
                Console.WriteLine("2) Create Physician");
                Console.WriteLine("3) See Availability");
                Console.WriteLine("4) Add Appointment");
                Console.Write("5) Exit\n\n>> ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        PatientProxy.Current.AddPatient();
                        // ^^^ Effectively calls the code from below
                        // Patient patient = PatientFactory.FromCli();
                        // patients.Add(patient);
                        break;

                    case "2":
                        PhysicianProxy.Current.AddPhysician();
                        // Physician physician = PhysicianFactory.FromCli();
                        // physicians.Add(physician);
                        break;

                    case "3":
                        // if (physicians.Count > 0)
                        // {
                        //     Tools.PhysicianList(ref physicians);
                        //     Console.Write($"\nEnter the name of the physician you wish to see the schedule for.\n>> ");
                        //     var output = Console.ReadLine();
                        //
                        //     foreach (var p in physicians)
                        //     {
                        //         if (p.lastName.ToUpper() == output.ToUpper())
                        //         {
                        //             p.ScheduleInfo();
                        //         }
                        //     }
                        // }
                        // else
                        // {
                        //     Console.WriteLine($"No physicians are available.");
                        // }

                        break;

                    case "4":
                        // if (physicians.Count == 0)
                        // {
                        //     Console.WriteLine("No physicians are available.");
                        //     break;
                        // }
                        //
                        // Tools.PhysicianList(ref physicians);
                        // Console.Write("Enter the physician you wish to see the schedule for.\n>> ");
                        // var physicianName = Console.ReadLine();
                        //
                        // var chosenPhysician = physicians.FirstOrDefault(p => p.lastName.ToUpper() == physicianName.ToUpper());
                        // if (chosenPhysician == null)
                        // {
                        //     Console.WriteLine("No physician was found.");
                        //     break;
                        // }
                        //
                        // Console.Write("Enter a day (1 = Mon, 5 = Fri):\n>> ");
                        // int dayIdx = int.Parse(Console.ReadLine())-1;
                        //
                        // Console.Write("Enter time (HH:MM):\n>> ");
                        // TimeSpan time = TimeSpan.Parse(Console.ReadLine());
                        //
                        // Console.Write("Notes:\n>> ");
                        // var notes = Console.ReadLine();
                        //
                        // bool booked = chosenPhysician.AddAppointment(dayIdx, time, notes);
                        // Console.WriteLine(booked ?  "Appointment booked." : "Time not Available.");

                        break;
                    
                    case "5":
                        cont = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("");
                // Console.Clear();    // Optional, just for style.
            }
        }
    }