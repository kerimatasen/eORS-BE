using eORS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eORS.Domain.Interfaces
{

    public interface IAppointmentRepository
    {
        Task AddAsync(Appointment appointment);
        Task<IEnumerable<Appointment>> FindByStudentIdAsync(int studentId);
    }

}
