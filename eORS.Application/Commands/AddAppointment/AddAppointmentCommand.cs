using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eORS.Application.Commands.AddAppointment
{
    public class AddAppointmentCommand
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set;} = DateTime.Now;

    }
}
