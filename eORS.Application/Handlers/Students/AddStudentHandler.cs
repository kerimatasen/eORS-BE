using System.Threading;
using System.Threading.Tasks;
using MediatR;
using eORS.Application.Commands.Students;
using eORS.Domain.Entities;
using eORS.Domain.Interfaces;
using eORS.Application.Commands.Teachers;

namespace eORS.Application.Handlers.Students
{
    public class AddStudentHandler : IRequestHandler<AddStudentCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddStudentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Email = request.Email,
                Address = request.Address,
                City = request.City,
                District = request.District,
                Image = request.Image,
                TC = request.TC,
                Password = request.Password,
                ParentName = request.ParentName,
                ParentPhone = request.ParentPhone,
                ParentEmail = request.ParentEmail,
                Class = request.Class.ToString(),
                CompanyId = request.CompanyId
            };

            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.CompleteAsync();

            return student.Id;
        }


    }
}
