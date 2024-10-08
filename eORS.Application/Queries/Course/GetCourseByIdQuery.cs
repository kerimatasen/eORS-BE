using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using eORS.Domain.Entities;
namespace eORS.Application.Queries.TeacherSchedulesQuery {



    public class GetCourseByIdQuery : IRequest<Course>
    {
        public int Id { get; set; }
    }

}
    // GetCourseByIdQuery.cs




