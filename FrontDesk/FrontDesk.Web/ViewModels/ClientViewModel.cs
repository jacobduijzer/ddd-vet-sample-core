using System.Collections.Generic;

namespace FrontDesk.Web.ViewModels
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public IEnumerable<PatientViewModel> Patients { get; set; }
    }
}
