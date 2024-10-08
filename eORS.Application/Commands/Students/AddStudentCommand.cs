using MediatR;

namespace eORS.Application.Commands.Students
{
    public class AddStudentCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Image { get; set; }
        public string TC { get; set; }
        public string Password { get; set; }
        public string ParentName { get; set; }
        public string ParentPhone { get; set; }
        public string ParentEmail { get; set; }
        public string Class { get; set; }
        public int CompanyId { get; set; }
    }
}
