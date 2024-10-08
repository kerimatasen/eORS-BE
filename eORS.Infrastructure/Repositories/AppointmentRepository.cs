using eORS.Domain.Entities;
using eORS.Domain.Interfaces;
using eORS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eORS.Infrastructure.Repositories
{

    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }

        public async Task<IEnumerable<Appointment>> FindByStudentIdAsync(int studentId)
        {
            return await _context.Appointments
                .Where(a => a.StudentId == studentId)
                .ToListAsync();
        }
    }

}
