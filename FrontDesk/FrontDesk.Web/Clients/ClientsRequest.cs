using System.Collections.Generic;
using ClientPatientManagement.Core.Models;
using FrontDesk.Web.ViewModels;
using MediatR;

namespace FrontDesk.Web.Clients
{
    public class ClientsRequest : IRequest<IEnumerable<ClientViewModel>>
    {        
    }
}
