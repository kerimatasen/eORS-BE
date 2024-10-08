using MediatR;
using eORS.Infrastructure.Data;

public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, int>
{
    private readonly AppDbContext _context;

    public UpdateCourseCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await _context.Courses.FindAsync(request.CourseId);
        if (course == null) return 0;

        course.CourseName = request.CourseName;
        course.CompanyId = request.CompanyId;

        // Mevcut öğretmen ilişkilerini temizleyip yeniden ekliyoruz.
        course.Teachers.Clear();

        foreach (var teacherId in request.TeacherIds)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            if (teacher != null)
            {
                course.Teachers.Add(teacher);
            }
        }

        _context.Courses.Update(course);
        await _context.SaveChangesAsync(cancellationToken);

        return course.CourseId;
    }
}
