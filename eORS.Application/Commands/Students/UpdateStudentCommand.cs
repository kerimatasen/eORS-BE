using eORS.Domain.Entities;
using MediatR;

namespace eORS.Application.Commands.Students
{
    public class UpdateStudentCommand : IRequest<bool>
    {
        public int Id { get; set; }
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
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        // Navigation Properties
        public ICollection<Appointment> Appointments { get; set; }
    }
}
