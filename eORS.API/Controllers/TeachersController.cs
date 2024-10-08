using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using eORS.Application.Commands.Teachers;
using eORS.Application.Queries.Teachers;
using eORS.Domain.Entities;

namespace eORS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeachersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(AddTeacherCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            var query = new GetAllTeachersQuery();
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
