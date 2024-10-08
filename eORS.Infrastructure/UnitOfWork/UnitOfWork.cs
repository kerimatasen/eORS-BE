using System.Threading.Tasks;
using eORS.Domain.Interfaces;
using eORS.Infrastructure.Data;
using eORS.Infrastructure.Repositories;

namespace eORS.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Teachers = new TeacherRepository(_context);
            Students = new StudentRepository(_context);
            Courses = new CourseRepository(_context);
            Appointments = new AppointmentRepository(_context);
        }

        public ITeacherRepository Teachers { get; private set; }
        public IStudentRepository Students { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public IAppointmentRepository Appointments { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
