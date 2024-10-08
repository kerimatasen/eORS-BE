using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eORS.Domain.Entities
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Role { get; set; } // "Admin", "Teacher", "Student"
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        // Bağlantılar
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<TeacherSchedule> Schedules { get; set; }
    }

}
