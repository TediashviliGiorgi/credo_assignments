namespace MovieDatabase.API.DB.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string Course { get; set; }
        public double StudentGPA { get; set; }
    }
}
