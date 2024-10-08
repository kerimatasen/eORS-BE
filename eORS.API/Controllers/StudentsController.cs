using eORS.Application.Commands.Students;
using eORS.Application.Queries.Students;
using eORS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eORS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IMediator mediator, ILogger<StudentsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        // GET: api/Students
        [HttpGet]
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var query = new GetAllStudentsQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentCommand command)
        {
            _logger.LogInformation("AddStudent method called.");
            var result = await _mediator.Send(command);
            _logger.LogInformation("Student added successfully: {@Student}", result);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentCommand command)
        {
            _logger.LogInformation("UpdateStudent method called for student with ID {StudentId}.", id);
            if (id != command.Id)
            {
                _logger.LogWarning("Student ID mismatch. URL ID: {UrlId}, Command ID: {CommandId}", id, command.Id);
                return BadRequest("Invalid student ID.");
            }

            var result = await _mediator.Send(command);
            _logger.LogInformation("Student updated successfully: {@Student}", command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            _logger.LogInformation("DeleteStudent method called for student with ID {StudentId}.", id);
            var result = await _mediator.Send(new DeleteStudentCommand { Id = id });
            _logger.LogInformation("Student deleted successfully: ID {StudentId}", id);
            return Ok(result);
        }
    }
}
