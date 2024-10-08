using eORS.Application.Queries.Appointment;
using eORS.Domain.Entities;
using eORS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eORS.Application.Handlers.AddAppointment
{
    public class GetStudentAppointmentsHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStudentAppointmentsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Appointment>> Handle(GetStudentAppointmentsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Appointments.FindByStudentIdAsync(request.StudentId);
        }
    }

}
