using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontDesk.Web.Doctors;
using FrontDesk.Web.Pages.Shared;
using MediatR;

namespace FrontDesk.Web.Pages
{
    public class DoctorsModel : PageModelBase
    {

        public DoctorsModel(IMediator mediator) : base(mediator)
        {

        }

        public IList<DoctorViewModel> Doctors { get; private set; }

        public async Task OnGetAsync()
        {
            var doctors = await Mediator.Send(new DoctorsRequest()).ConfigureAwait(false);
            if (doctors.Any())
                Doctors = new List<DoctorViewModel>(doctors);
        }
    }
}
