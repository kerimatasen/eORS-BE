using MediatR;

namespace eORS.Application.Commands.Students
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
