using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontDesk.Web.Pages.Shared;
using FrontDesk.Web.Rooms;
using MediatR;

namespace FrontDesk.Web.Pages
{
    public class RoomsModel : PageModelBase
    {
        public RoomsModel(IMediator mediator) : base(mediator)
        {
        }

        public IList<RoomViewModel> Rooms { get; private set; }

        public async Task OnGetAsync()
        {
            var rooms = await Mediator.Send(new RoomsRequest()).ConfigureAwait(false);
            if (rooms.Any())
                Rooms = new List<RoomViewModel>(rooms);
        }
    }
}
