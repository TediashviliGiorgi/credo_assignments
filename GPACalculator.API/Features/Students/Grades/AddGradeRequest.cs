namespace GPACalculator.API.Features.Students.Grades
{
    public class AddGradeRequest
    {
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public int Score { get; set; }
    }
}
