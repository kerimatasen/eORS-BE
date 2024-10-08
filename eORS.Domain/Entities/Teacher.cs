using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eORS.Domain.Entities
{
    [Table("Teacher")]
    public class Teacher
    {
        public int Id { get; set; }
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

        // Şirket ile ilişki
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        // Öğretmen ve randevular arasında 1'e çok ilişki
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        // Öğretmen ve öğretmen programı arasında 1'e çok ilişki
        public ICollection<TeacherSchedule> Schedules { get; set; } = new List<TeacherSchedule>();
    }
}
