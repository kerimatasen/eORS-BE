using System.Collections.Generic;
using MediatR;
using eORS.Domain.Entities;

namespace eORS.Application.Queries.Teachers
{
    public class GetAllTeachersQuery : IRequest<IEnumerable<Teacher>>
    {
    }
}
