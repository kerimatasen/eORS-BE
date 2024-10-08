using eORS.Application.Commands.Students;
using eORS.Domain.Entities;
using eORS.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace eORS.Application.Handlers.Students
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStudentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(request.Id);
            if (student == null) return false;

           // await _unitOfWork.Students.DeleteAsync(student);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
