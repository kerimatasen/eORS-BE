using System.Threading;
using System.Threading.Tasks;
using MediatR;
using eORS.Application.Commands.Teachers;
using eORS.Domain.Entities;
using eORS.Domain.Interfaces;

namespace eORS.Application.Handlers.Teachers
{
    public class AddTeacherHandler : IRequestHandler<AddTeacherCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddTeacherHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = new Teacher
            {
                Username = request.Username,
                Name = request.Name,
                Phone = request.Phone,
                Email = request.Email,
                Address = request.Address,
                City = request.City,
                District = request.District,
                Image = request.Image,
                TC = request.TC,
                Password = request.Password,
                CompanyId = request.CompanyId
            };

            await _unitOfWork.Teachers.AddAsync(teacher);
            await _unitOfWork.CompleteAsync();

            return teacher.Id;
        }
    }
}
