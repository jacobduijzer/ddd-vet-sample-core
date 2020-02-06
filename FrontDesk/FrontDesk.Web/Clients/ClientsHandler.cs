using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClientPatientManagement.Core.Interfaces;
using ClientPatientManagement.Core.Models;
using FrontDesk.Web.ViewModels;
using MediatR;

namespace FrontDesk.Web.Clients
{
    public class ClientsHandler : IRequestHandler<ClientsRequest, IEnumerable<ClientViewModel>>
    {
        private readonly IRepository<Client> _clientRepository;

        public ClientsHandler(IRepository<Client> clientRepository) => _clientRepository = clientRepository;

        public async Task<IEnumerable<ClientViewModel>> Handle(ClientsRequest request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.List().ConfigureAwait(false);

            return clients.Select(c => new ClientViewModel()
            {
                ClientId = c.Id,
                FullName = c.FullName,
                Patients = c.Patients.Select(p => new PatientViewModel()
                {
                    Name = p.Name,
                    PatientId = p.Id,
                    PreferredDoctorId = p.PreferredDoctorId.Value
                }).OrderBy(p => p.Name)
            })
            .OrderBy(c => c.FullName);
        }   
    }
}
