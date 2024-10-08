using System.ComponentModel.DataAnnotations.Schema;

namespace eORS.Domain.Entities
{
    [Table("Course")]
    public class Course
    {
        public int CourseId { get; set; }
        public int CompanyId { get; set; }
        public string CourseName { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
