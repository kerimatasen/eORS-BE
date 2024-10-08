using eORS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eORS.Domain.Interfaces
{

    public interface ICourseRepository : IRepository<Course>
    {
        // Teacher için ek operasyonları burada tanımlayabilirsiniz
    }
}
