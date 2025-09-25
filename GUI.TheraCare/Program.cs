using Library.TheraCare.Models;
using Library.TheraCare.Services.Proxies;

namespace GUI.TheraCare;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to, CLITheraCare ===\n");

        bool cont = true, submenu = true;
        while (cont)
        {
            Console.WriteLine("1) Patient Menu");
            Console.WriteLine("2) Physician Menu");
            Console.WriteLine("3) See Availability");
            Console.WriteLine("4) Add Appointment");
            Console.Write("5) Exit\n\n>> ");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    while (submenu)
                    {
                        Console.WriteLine("\n1) Create Patient");
                        Console.WriteLine("2) Update Patient");
                        Console.WriteLine("3) Delete Patient");
                        Console.WriteLine("4) List patient");
                        Console.WriteLine("5) List all Patients");
                        Console.Write("6) Exit\n\n>> ");
                        string? submenu_choice = Console.ReadLine();
                        switch (submenu_choice)
                        {
                            case "1":
                                PatientProxy.Current.Create();
                                break;
                            case "2":
                                Console.Write("\nEnter GUID of Patient\n>> ");
                                var upCStr = Console.ReadLine() ?? "NONE";
                                Guid upGuid = Guid.Empty;
                                if (Guid.TryParse(upCStr, out upGuid))
                                {
                                    PatientProxy.Current.UpdatePatient(upGuid);
                                }

                                break;
                            case "3":
                                Console.Write("\nEnter GUID of Patient\n>> ");
                                var delCStr = Console.ReadLine() ?? "NONE";
                                Guid delGuid = Guid.Empty;
                                if (Guid.TryParse(delCStr, out delGuid))
                                {
                                    PatientProxy.Current.Delete(delGuid);
                                }

                                break;
                            case "4":
                                Console.Write("\nEnter GUID of Patient\n>> ");
                                var findUser = Console.ReadLine() ?? "NONE";
                                Guid findGuid = Guid.Empty;
                                if (Guid.TryParse(findUser, out findGuid))
                                {
                                    Patient p = PatientProxy.Current.GetPatient(findGuid);
                                    Console.WriteLine($"{p.LastName}, {p.FirstName}: FOUND");
                                }
                                else
                                {
                                    Console.WriteLine("There is no Patient with the given GUID");
                                }

                                break;
                            case "5":
                                PatientProxy.Current.DisplayPatients();
                                break;
                            case "6":
                                submenu = false;
                                break;
                        }

                        Console.WriteLine();
                    }

                    submenu = true;
                    break;

                case "2":
                    while (submenu)
                    {
                        Console.WriteLine("\n1) Create Physician");
                        Console.WriteLine("2) Update Physician");
                        Console.WriteLine("3) Delete Physician");
                        Console.WriteLine("4) List Physician");
                        Console.WriteLine("5) List all Physicians");
                        Console.Write("6) Exit\n\n>> ");
                        string? submenu_choice = Console.ReadLine();
                        switch (submenu_choice)
                        {
                            case "1":
                                PhysicianProxy.Current.CreatePhysician();
                                break;
                            case "2":
                                Console.Write("\nEnter GUID of Physician\n>> ");
                                var upCStr = Console.ReadLine() ?? "NONE";
                                Guid upGuid = Guid.Empty;
                                if (Guid.TryParse(upCStr, out upGuid))
                                {
                                    PhysicianProxy.Current.UpdatePhysician(upGuid);
                                }

                                break;

                            case "3":
                                Console.Write("\nEnter GUID of Physician\n>> ");
                                var delCStr = Console.ReadLine() ?? "NONE";
                                Guid delGuid = Guid.Empty;
                                if (Guid.TryParse(delCStr, out delGuid))
                                {
                                    PhysicianProxy.Current.DeletePhysician(delGuid);
                                }

                                break;
                            case "4":
                                Console.Write("\nEnter GUID of Physician\n>> ");
                                var findUser = Console.ReadLine() ?? "NONE";
                                Guid findGuid = Guid.Empty;
                                if (Guid.TryParse(findUser, out findGuid))
                                {
                                    Physician? p = PhysicianProxy.Current.GetPhysician(findGuid);
                                    Console.WriteLine($"{p?.LastName}, {p?.FirstName}: FOUND");
                                }
                                else
                                {
                                    Console.WriteLine("There is no Patient with the given GUID");
                                }

                                break;
                            case "5":
                                PhysicianProxy.Current.DisplayPhysicians();
                                break;
                            case "6":
                                submenu = false;
                                break;
                        }

                        Console.WriteLine();
                    }

                    submenu = true;
                    break;

                case "3":
                    
                    break;

                case "4":
                    PatientProxy.Current.DisplayPatients();
                    break;

                case "6":
                    Console.Write("\nEnter GUID of Patient\n>> ");
                    var input = Console.ReadLine() ?? "NONE";
                    Guid guid = Guid.Empty;
                    if (Guid.TryParse(input, out guid))
                    {
                        Patient p = PatientProxy.Current.GetPatient(guid);
                        Console.WriteLine($"{p.LastName}, {p.FirstName}: FOUND");
                    }
                    else
                    {
                        Console.WriteLine("There is no Patient with the given GUID");
                    }

                    break;

                case "7":
                    Console.Write("\nEnter GUID of Patient\n>> ");
                    var input2 = Console.ReadLine() ?? "NONE";
                    Guid nguid = Guid.Empty;
                    if (Guid.TryParse(input2, out nguid))
                    {
                        PatientProxy.Current.UpdatePatient(nguid);
                    }

                    break;

                case "8":
                    Console.Write("\nEnter GUID of Patient\n>> ");
                    var input3 = Console.ReadLine() ?? "NONE";
                    Guid nNguid = Guid.Empty;
                    if (Guid.TryParse(input3, out nNguid))
                    {
                        PatientProxy.Current.Delete(nNguid);
                    }

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