using System.Threading.Tasks;

namespace eORS.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ITeacherRepository Teachers { get; }
        IStudentRepository Students { get; }
        ICourseRepository Courses { get; }
        IAppointmentRepository Appointments { get; }
        Task<int> CompleteAsync();
    }
}
