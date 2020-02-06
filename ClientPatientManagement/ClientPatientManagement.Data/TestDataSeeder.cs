using System.Linq;
using ClientPatientManagement.Core.Models;
using FrontDesk.SharedKernel.Enums;

namespace ClientPatientManagement.Data
{
    public static class TestDataSeeder
    {
        public static void Seed(this CrudContext crudContext)
        {
            var drSmith = new Doctor { Name = "Dr. Smith" };
            var drWho = new Doctor { Name = "Dr. Who" };
            var drMcDreamy = new Doctor { Name = "Dr. McDreamy" };

            if (!crudContext.Doctors.Any())
            {
                crudContext.Doctors.AddRange(drSmith, drWho, drMcDreamy);

                crudContext.SaveChanges();
            }

            var clientSteve = new Client
            {
                FullName = "Steve Smith",
                PreferredName = "Steve",
                Salutation = "Mr.",
                PreferredDoctorId = drSmith.Id
            };

            var clientJulie = new Client
            {
                FullName = "Julia Lerman",
                PreferredName = "Julie",
                Salutation = "Mrs.",
                PreferredDoctorId = drMcDreamy.Id
            };

            if (!crudContext.Clients.Any())
            {
                crudContext.Clients.Add(clientSteve);
                crudContext.Clients.Add(clientJulie);
                crudContext.SaveChanges();
            }

            if(!crudContext.Patients.Any())
            {
                crudContext.Patients.Add(new Patient(clientSteve) { Gender = Gender.Male, Name = "Darwin" });
                crudContext.Patients.Add(new Patient(clientSteve) { Gender = Gender.Female, Name = "Rumor", PreferredDoctorId = drWho.Id });
                crudContext.Patients.Add(new Patient(clientJulie) { Gender = Gender.Male, Name = "Sampson" });

                crudContext.SaveChanges();
            }

            if(!crudContext.Rooms.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var room = new Room { Name = string.Format("Exam Room {0}", i + 1) };
                    crudContext.Rooms.Add(room);
                }

                crudContext.SaveChanges();
            }
        }
    }
}
