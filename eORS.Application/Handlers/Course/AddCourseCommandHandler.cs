

using eORS.Application.Commands.Course;
using eORS.Domain.Entities;
using eORS.Infrastructure.Data;
using MediatR;

public class AddCourseCommandHandler : IRequestHandler<AddCourseCommand, int>
{
    private readonly AppDbContext _context;

    public AddCourseCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AddCourseCommand request, CancellationToken cancellationToken)
    {
        var course = new Course
        {
            CourseName = request.CourseName,
            Teachers = new List<Teacher>(),
            CompanyId = request.CompanyId
        };
        foreach (var teacherId in request.TeacherIds)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            if (teacher != null)
            {
                course.Teachers.Add(teacher);
            }
        }
        _context.Courses.Add(course);
        await _context.SaveChangesAsync(cancellationToken);

        return course.CourseId;
    }
}
