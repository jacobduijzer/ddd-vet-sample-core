using System.Collections.Generic;
using MediatR;

namespace FrontDesk.Web.Doctors
{
    public class DoctorsRequest : IRequest<IEnumerable<DoctorViewModel>>
    {
    }
}
