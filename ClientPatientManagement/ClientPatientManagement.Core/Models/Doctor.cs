using ClientPatientManagement.Core.Interfaces;

namespace ClientPatientManagement.Core.Models
{
    public class Doctor : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
