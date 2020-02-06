using ClientPatientManagement.Core.Models;
using FluentAssertions;
using FrontDesk.SharedKernel.Enums;
using Xunit;

namespace ClientPatientManagement.Core.UnitTests.Models
{
    public class PatientShould
    {
        [Fact]
        public void HaveAFewProperties()
        {
            var testName = "Darwin";
            var testGender = Gender.Male;
            var patient = new Patient(new Client())
            {
                Name = testName,
                Gender = testGender
            };

            patient.Name.Should().Be(testName);
            patient.Gender.Should().Be(testGender);
        }

        [Fact]
        public void HaveAnOwner()
        {
            var client = new Client();
            var patient = new Patient(client);

            patient.Owner.Should().Be(client);
        }

        [Fact]
        public void HavePreferredDoctorDefaultToClientPreferredDoctor()
        {
            var client = new Client();
            var doctor = new Doctor();
            client.PreferredDoctorId = doctor.Id;

            var patient = new Patient(client);
            patient.PreferredDoctorId.Should().Be(client.PreferredDoctorId);
        }
    }
}
