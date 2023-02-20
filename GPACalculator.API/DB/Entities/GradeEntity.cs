namespace GPACalculator.API.DB.Entities
{
    public class GradeEntity
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public int Score { get; set; }
        public SubjectEntity Subject { get; set; }
        public StudentEntity Student { get; set; }
    }
}
