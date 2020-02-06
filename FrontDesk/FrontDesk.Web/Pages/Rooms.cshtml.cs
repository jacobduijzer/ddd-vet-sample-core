using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontDesk.Web.Rooms;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontDesk.Web.Pages
{
    public class RoomsModel : PageModel
    {
        private readonly IMediator _mediator;

        public RoomsModel(IMediator mediator) => _mediator = mediator;

        public string NameSort { get; set; }
        
        public IList<RoomViewModel> Rooms { get; private set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var rooms = await _mediator.Send(new RoomsRequest(x => x.Name)).ConfigureAwait(false);
            if (rooms.Any())
            {
                if(string.IsNullOrEmpty(sortOrder))
                    Rooms = new List<RoomViewModel>(rooms.OrderByDescending(x => x.Name));
                else
                    Rooms = new List<RoomViewModel>(rooms.OrderBy(x => x.Name));
            }
                
        }
    }
}
