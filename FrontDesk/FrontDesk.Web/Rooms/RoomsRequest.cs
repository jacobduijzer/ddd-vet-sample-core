using System.Collections.Generic;
using MediatR;

namespace FrontDesk.Web.Rooms
{
    public class RoomsRequest : IRequest<IEnumerable<RoomViewModel>>
    {

    }
}
