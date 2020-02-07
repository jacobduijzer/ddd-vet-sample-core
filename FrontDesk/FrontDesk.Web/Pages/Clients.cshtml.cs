using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontDesk.Web.Clients;
using FrontDesk.Web.Pages.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontDesk.Web.Pages
{
    //https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-3.1
    public class ClientsModel : PageModelBase
    {
        public ClientsModel(IMediator mediator) : base(mediator)
        {

        }

        public IList<ClientViewModel> Clients { get; private set; }

        public async Task OnGetAsync()
        {
            var clients = await Mediator.Send(new ClientsRequest()).ConfigureAwait(false);
            if (clients.Any())
                Clients = new List<ClientViewModel>(clients);
        }
    }
}
