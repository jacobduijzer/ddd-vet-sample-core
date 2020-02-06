using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontDesk.Web.Clients;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontDesk.Web.Pages
{
    //https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-3.1
    public class ClientsModel : PageModel
    {
        private readonly IMediator _mediator;

        public ClientsModel(IMediator mediator) => _mediator = mediator;

        public IList<ClientViewModel> Clients { get; private set; }

        public async Task OnGetAsync()
        {
            var clients = await _mediator.Send(new ClientsRequest()).ConfigureAwait(false);
            if (clients.Any())
                Clients = new List<ClientViewModel>(clients);
        }
    }
}
