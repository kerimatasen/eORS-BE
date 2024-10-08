using eORS.Application.Commands.AddAppointment;
using eORS.Domain.Entities;
using eORS.Domain.Interfaces;

public class AddAppointmentHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public AddAppointmentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = new Appointment
        {
            StudentId = request.StudentId,
            TeacherId = request.TeacherId,
            CreatedDate = request.CreatedDate,
            UpdatedDate = request.UpdatedDate,
            Status = "Scheduled"
        };

        await _unitOfWork.Appointments.AddAsync(appointment);
        await _unitOfWork.CompleteAsync();
    }
}
