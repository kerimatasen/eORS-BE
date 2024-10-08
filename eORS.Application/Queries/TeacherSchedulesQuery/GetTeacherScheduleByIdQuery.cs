using eORS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eORS.Application.Queries.TeacherSchedulesQuery
{

    public class GetTeacherScheduleByIdQuery : IRequest<Course>
    {
        public int Id { get; set; }
    }
}
