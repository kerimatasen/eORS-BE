using eORS.Domain.Entities;
using eORS.Domain.Interfaces;
using eORS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eORS.Infrastructure.Repositories
{

    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context)
        {
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        // Teacher için özel metodlar burada tanımlanabilir
    }
}
