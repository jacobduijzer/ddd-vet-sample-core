using System.Collections.Generic;

namespace FrontDesk.Web.Clients
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public IEnumerable<PatientViewModel> Patients { get; set; }
    }
}
