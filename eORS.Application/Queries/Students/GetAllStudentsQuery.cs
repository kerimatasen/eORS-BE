using System.Collections.Generic;
using MediatR;
using eORS.Domain.Entities;

namespace eORS.Application.Queries.Students
{
    public class GetAllStudentsQuery : IRequest<IEnumerable<Student>>
    {
    }
}
