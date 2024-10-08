using eORS.Domain.Entities;
using eORS.Domain.Interfaces;
using eORS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eORS.Infrastructure.Repositories
{

    public class StudentRepository : Repository<Student>,IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
