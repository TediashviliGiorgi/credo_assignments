namespace GPACalculator.API.DB.Entities
{
    public class GPAEntity
    {
        public int Id { get; set; } 
        public int StudentId { get; set; }
        public double GPA {get; set; }
    }
}
