using eORS.Domain.Entities;
using eORS.Domain.Interfaces;
using eORS.Infrastructure.Data;

namespace eORS.Infrastructure.Repositories
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context)
        {
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        // Teacher için özel metodlar burada tanımlanabilir
    }
}
