using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontDesk.Web.Doctors;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontDesk.Web.Pages
{
    public class DoctorsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DoctorsModel(IMediator mediator) => _mediator = mediator;

        public IList<DoctorViewModel> Doctors { get; private set; }

        public async Task OnGetAsync()
        {
            var doctors = await _mediator.Send(new DoctorsRequest()).ConfigureAwait(false);
            if (doctors.Any())
                Doctors = new List<DoctorViewModel>(doctors);
        }
    }
}
