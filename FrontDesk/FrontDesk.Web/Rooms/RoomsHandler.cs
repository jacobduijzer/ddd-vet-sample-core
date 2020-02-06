using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClientPatientManagement.Core.Interfaces;
using ClientPatientManagement.Core.Models;
using MediatR;

namespace FrontDesk.Web.Rooms
{
    public class RoomsHandler : IRequestHandler<RoomsRequest, IEnumerable<RoomViewModel>>
    {
        private readonly IRepository<Room> _roomRepository;

        public RoomsHandler(IRepository<Room> roomRepository) => _roomRepository = roomRepository;

        public async Task<IEnumerable<RoomViewModel>> Handle(RoomsRequest request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.List().ConfigureAwait(false);
            return rooms.Select(x => new RoomViewModel { RoomId = x.Id, Name = x.Name });
        }
    }
}
