using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace eORS.Domain.Entities
{
    [Table("Appointment")]
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Status { get; set; } // Örnek: "Onaylandı", "İptal Edildi", vb.

        // Randevu ve Öğretmen ilişkisi (1'e çok)
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        // Randevu ve Öğrenci ilişkisi (1'e çok)
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
