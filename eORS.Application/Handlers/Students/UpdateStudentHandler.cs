using eORS.Application.Commands.Students;
using eORS.Domain.Entities;
using eORS.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace eORS.Application.Handlers.Students
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStudentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(request.Id);
            if (student == null) return false;

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Email = request.Email;
            student.Phone = request.Phone;
            student.City = request.City;
            student.Address = request.Address;
            student.District = request.District;
            student.Image = request.Image;
            student.Password = request.Password;
            student.ParentPhone = request.ParentPhone;
            student.ParentName = request.ParentName;
            student.ParentEmail = request.ParentEmail;
            student.TC= request.TC;
            student.Class = request.Class;
            student.Appointments = request.Appointments;


        await _unitOfWork.Students.UpdateAsync(student);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
