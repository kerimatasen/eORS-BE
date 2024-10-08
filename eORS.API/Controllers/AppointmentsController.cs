using eORS.Application.Commands.AddAppointment;
using eORS.Application.Queries.Appointment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddAppointment(AddAppointmentCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetStudentAppointments(int studentId)
    {
        var query = new GetStudentAppointmentsQuery { StudentId = studentId };
        var appointments = await _mediator.Send(query);
        return Ok(appointments);
    }
}
