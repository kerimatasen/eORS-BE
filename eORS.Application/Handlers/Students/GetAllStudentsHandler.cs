using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using eORS.Application.Queries.Students;
using eORS.Domain.Entities;
using eORS.Domain.Interfaces;

namespace eORS.Application.Handlers.Students
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllStudentsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public Task<IEnumerable<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return  _unitOfWork.Students.GetAllAsync();
        }



    }
}
