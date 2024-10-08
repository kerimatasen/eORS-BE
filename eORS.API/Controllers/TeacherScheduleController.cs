using eORS.Application.Commands.AddTeacherScheduleCommand;
using eORS.Application.Queries.TeacherSchedulesQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TeacherScheduleController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeacherScheduleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeacherSchedule([FromBody] CreateTeacherScheduleCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeacherScheduleById(int id)
    {
        var query = new GetTeacherScheduleByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTeacherSchedules()
    {
        var result = await _mediator.Send(new GetAllTeacherSchedulesQuery());
        return Ok(result);
    }

    // Diğer metodları ekleyin: Update, Delete...
}
