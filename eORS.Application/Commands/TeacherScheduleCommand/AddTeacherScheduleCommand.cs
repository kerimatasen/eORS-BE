using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace eORS.Application.Commands.AddTeacherScheduleCommand
{
    // CreateTeacherScheduleCommand.cs


    public class CreateTeacherScheduleCommand : IRequest<int>
    {
        public int TeacherId { get; set; }
        public string AvailableDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }

}
