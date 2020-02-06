using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MediatR;

namespace FrontDesk.Web.Rooms
{
    public class RoomsRequest : IRequest<IEnumerable<RoomViewModel>>
    {
        public readonly Expression<Func<RoomViewModel, dynamic>> OrderByExpression;

        public RoomsRequest(Expression<Func<RoomViewModel, dynamic>> orderByExpression) =>
            OrderByExpression = orderByExpression;
    }
}
