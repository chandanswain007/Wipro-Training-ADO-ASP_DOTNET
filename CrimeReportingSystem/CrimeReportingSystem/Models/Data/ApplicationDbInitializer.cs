using CrimeReportingSystem.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CrimeReportingSystem.Models.Data
{
    public static class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Victims.Any() || context.Suspects.Any() || context.LawEnforcementAgencies.Any())
            {
                return;
            }

            var victims = new Victim[]
            {
                new Victim { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1985, 5, 15), Gender = "Male", Address = "123 Main St", PhoneNumber = "555-1234" },
                new Victim { FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1990, 8, 22), Gender = "Female", Address = "456 Oak Ave", PhoneNumber = "555-5678" }
            };

            foreach (var v in victims)
            {
                context.Victims.Add(v);
            }
            context.SaveChanges();

            var suspects = new Suspect[]
            {
                new Suspect { FirstName = "Robert", LastName = "Johnson", DateOfBirth = new DateTime(1978, 3, 10), Gender = "Male", Address = "789 Pine Rd", PhoneNumber = "555-9012" },
                new Suspect { FirstName = "Sarah", LastName = "Williams", DateOfBirth = new DateTime(1982, 11, 5), Gender = "Female", Address = "321 Elm St", PhoneNumber = "555-3456" }
            };

            foreach (var s in suspects)
            {
                context.Suspects.Add(s);
            }
            context.SaveChanges();

            var agencies = new LawEnforcementAgency[]
            {
                new LawEnforcementAgency { AgencyName = "City Police Department", Jurisdiction = "Citywide", Address = "100 Police Plaza", PhoneNumber = "555-0001" },
                new LawEnforcementAgency { AgencyName = "County Sheriff's Office", Jurisdiction = "Countywide", Address = "200 Sheriff Ave", PhoneNumber = "555-0002" }
            };

            foreach (var a in agencies)
            {
                context.LawEnforcementAgencies.Add(a);
            }
            context.SaveChanges();

            var officers = new Officer[]
            {
                new Officer { FirstName = "Mike", LastName = "Anderson", BadgeNumber = "PD123", Rank = "Detective", PhoneNumber = "555-1001", AgencyID = 1 },
                new Officer { FirstName = "Lisa", LastName = "Taylor", BadgeNumber = "SO456", Rank = "Sergeant", PhoneNumber = "555-1002", AgencyID = 2 }
            };

            foreach (var o in officers)
            {
                context.Officers.Add(o);
            }
            context.SaveChanges();
        }
    }
}