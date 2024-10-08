using MediatR;

namespace eORS.Application.Commands.Teachers
{
    public class AddTeacherCommand : IRequest<int>
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Image { get; set; }
        public string TC { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
    }
}
