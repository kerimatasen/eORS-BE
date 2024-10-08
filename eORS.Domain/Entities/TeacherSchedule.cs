using System.ComponentModel.DataAnnotations.Schema;

namespace eORS.Domain.Entities
{
    [Table("TeacherSchedule")]
    public class TeacherSchedule
    {
        public int TeacherScheduleId { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int MaxAppointments { get; set; }
    }
}
