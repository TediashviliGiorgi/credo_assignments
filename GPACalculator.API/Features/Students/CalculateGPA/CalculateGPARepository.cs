using GPACalculator.API.DB;
using GPACalculator.API.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace GPACalculator.API.Features.Students.CalculateGPA
{
    public interface ICalculateGpaRepository
    {
        Task<List<StudentGrade>> GetStudentGradesAsync(int studentId);
    }
    public class CalculateGpaRepository : ICalculateGpaRepository
    {
        private readonly AppDbContext _db;
        public CalculateGpaRepository(AppDbContext db) 
        {
            _db = db; 
        }

        public async Task<List<StudentGrade>> GetStudentGradesAsync(int studentId)
        {
            var studentGrades = await _db.Grades
                .Where(g => g.StudentId == studentId)
                .Select(g => new StudentGrade
                {
                    StudentId = g.StudentId,
                    SubjectCredits = g.Subject.Credits,
                    Score = g.Score

                })
                .ToListAsync();

            return studentGrades;
        }

    }
}
