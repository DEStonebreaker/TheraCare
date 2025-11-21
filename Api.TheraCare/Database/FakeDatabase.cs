using System.Diagnostics.CodeAnalysis;
using Library.TheraCare.Services.Factories;

namespace Api.TheraCare.Database;

using Library.TheraCare.Models;

public static class FakeDatabase
{
    public static List<Patient> Patients = new List<Patient>
    {
        PatientFactory.FromArgs(
            fnIn: "Alice",
            lnIn: "Nguyen",
            addrIn: "123 Main St, Tallahassee, FL",
            bdIn: new DateTime(1999, 4, 12),
            raceIn: "Asian",
            genIn: "F",
            diagnosisIn: "Hypertension",
            medsIn: "Lisinopril"
        ),
        PatientFactory.FromArgs(
            fnIn: "Marcus",
            lnIn: "Reed",
            addrIn: "45 Oak Ave, Gainesville, FL",
            bdIn: new DateTime(1987, 10, 2),
            raceIn: "Black",
            genIn: "M",
            diagnosisIn: "Type 2 Diabetes",
            medsIn: "Metformin"
        ),
        PatientFactory.FromArgs(
            fnIn: "Sofia",
            lnIn: "Ramirez",
            addrIn: "9 Pine Blvd, Orlando, FL",
            bdIn: new DateTime(2001, 1, 27),
            raceIn: "Hispanic",
            genIn: "F",
            diagnosisIn: "Asthma",
            medsIn: "Albuterol"
        ),
        PatientFactory.FromArgs(
            fnIn: "Ethan",
            lnIn: "Chen",
            addrIn: "77 Lakeview Dr, Jacksonville, FL",
            bdIn: new DateTime(1995, 6, 5),
            raceIn: "Asian",
            genIn: "M",
            diagnosisIn: "Anxiety",
            medsIn: "Sertraline"
        ),
        PatientFactory.FromArgs(
            fnIn: "Grace",
            lnIn: "Henderson",
            addrIn: "501 River Rd, Miami, FL",
            bdIn: new DateTime(1978, 12, 19),
            raceIn: "White",
            genIn: "F",
            diagnosisIn: "Hyperlipidemia",
            medsIn: "Atorvastatin"
        ),
    };
}