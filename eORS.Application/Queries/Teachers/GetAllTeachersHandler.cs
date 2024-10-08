using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using eORS.Application.Queries.Teachers;
using eORS.Domain.Entities;
using eORS.Domain.Interfaces;

namespace eORS.Application.Handlers.Teachers
{
    public class GetAllTeachersHandler : IRequestHandler<GetAllTeachersQuery, IEnumerable<Teacher>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTeachersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Teacher>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Teachers.GetAllAsync();
        }
    }
}
