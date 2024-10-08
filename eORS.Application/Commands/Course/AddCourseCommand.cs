using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eORS.Application.Commands.Course
{
    // CreateCourseCommand.cs
    using MediatR;

    public class AddCourseCommand : IRequest<int>
    {
        public string CourseName { get; set; }
        public List<int> TeacherIds { get; set; }
        public int CompanyId { get; set; }
    }

}
