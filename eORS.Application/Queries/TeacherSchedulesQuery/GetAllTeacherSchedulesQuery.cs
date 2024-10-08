using System;
using System.Collections.Generic;
using System.Linq;
using eORS.Domain.Entities;
// GetAllTeacherSchedulesQuery.cs
using MediatR;

namespace eORS.Application.Queries.TeacherSchedulesQuery
{


    public class GetAllTeacherSchedulesQuery : IRequest<List<TeacherSchedule>>
    {
    }

}
