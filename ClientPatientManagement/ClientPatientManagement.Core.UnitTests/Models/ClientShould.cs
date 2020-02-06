using ClientPatientManagement.Core.Models;
using FluentAssertions;
using Xunit;

namespace ClientPatientManagement.Core.UnitTests.Models
{
    public class ClientShould
    {
        [Fact]
        public void HaveAListOfPatients()
        {
            var client = new Client();

            var patients = client.Patients;
            patients.Should().NotBeNull();
        }
    }
}
