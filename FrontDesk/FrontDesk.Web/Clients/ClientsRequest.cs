using System.Collections.Generic;
using MediatR;

namespace FrontDesk.Web.Clients
{
    public class ClientsRequest : IRequest<IEnumerable<ClientViewModel>>
    {        
    }
}
