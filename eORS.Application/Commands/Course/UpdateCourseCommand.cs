using MediatR;

public class UpdateCourseCommand : IRequest<int>
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public int CompanyId { get; set; }
    public List<int> TeacherIds { get; set; }
}
