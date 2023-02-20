using GPACalculator.API.DB;
using GPACalculator.API.DB.Entities;
using System.Diagnostics;

namespace GPACalculator.API.Features.Students.Grades
{
    public interface IAddGradeRepository
    {
        Task<GradeEntity> AddGradeAsync(AddGradeRequest request);
        bool Exists(int studentId, int subjectId);
    }
    public class AddGradeRepository : IAddGradeRepository
    {
        private readonly AppDbContext _db;
        public AddGradeRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<GradeEntity> AddGradeAsync(AddGradeRequest request)
        {
            var newGrade = new GradeEntity();
            newGrade.StudentId = request.StudentId;
            newGrade.Score = request.Score;
            newGrade.SubjectId = request.SubjectId;

            if (request.Score < 0 && request.Score > 100)
            {
                throw new ArgumentException("Grade should be a range 0 - 100");
            }

            await _db.Grades.AddAsync(newGrade);
            await _db.SaveChangesAsync();

            return newGrade;
        }

        public bool Exists(int studentId, int subjectId)
        {
            return _db.Grades.Any(g => g.StudentId == studentId && g.SubjectId == subjectId);
        }
    }
}
