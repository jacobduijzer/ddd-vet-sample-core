using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClientPatientManagement.Core.Interfaces;
using ClientPatientManagement.Core.Models;
using MediatR;

namespace FrontDesk.Web.Doctors
{
    public class DoctorsHandler : IRequestHandler<DoctorsRequest, IEnumerable<DoctorViewModel>>
    {
        private readonly IRepository<Doctor> _doctorRepository;

        public DoctorsHandler(IRepository<Doctor> doctorRepository) => _doctorRepository = doctorRepository;

        public async Task<IEnumerable<DoctorViewModel>> Handle(DoctorsRequest request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.List().ConfigureAwait(false);

            return doctors.Select(d => new DoctorViewModel()
            {
                DoctorId = d.Id,
                Name = d.Name
            });
        }
    }
}
