using GPACalculator.API.DB;
using GPACalculator.API.DB.Entities;
using GPACalculator.API.Features.Students.CalculateGPA;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace GPACalculator.API.Features.Students.GetStat
{
    public interface IGetStatRepository
    {
        Task<List<GPAEntity>> GetTop10StudentAsync();
        Task<List<GradeEntity>> GetTop3SubjectAsync();
        Task<List<GradeEntity>> GetLow3SubjectAsync();
    }
    public class GetStatRepository : IGetStatRepository
    {
        private readonly AppDbContext _db;

        public GetStatRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<GPAEntity>> GetTop10StudentAsync()
        {
            var top10Student = await _db.GPAs
                .OrderByDescending(x => x.GPA)
                .Take(10)
                .ToListAsync();
            return top10Student;
        }

        public async Task<List<GradeEntity>> GetTop3SubjectAsync()
        {
            var top3SubjectsByAvgScore = await _db.Grades
            .GroupBy(g => g.SubjectId)
            .Select(g => new GradeEntity
            {
            SubjectId = g.Key,
            Score = (int)g.OrderByDescending(x => x.Score).Take(3).Average(x => x.Score)
             })
            .OrderByDescending(x => x.Score)
            .Take(3)
            .ToListAsync();

            return top3SubjectsByAvgScore;
        }


        public async Task<List<GradeEntity>> GetLow3SubjectAsync()
        {
            var low3SubjectsByAvgScore = await _db.Grades
            .GroupBy(g => g.SubjectId)
            .Select(g => new GradeEntity
            {
                SubjectId = g.Key,
                Score = (int)g.OrderByDescending(x => x.Score).Take(3).Average(x => x.Score)
            })
            .OrderByDescending(x => x.Score)
            .Reverse()
            .Take(3)
            .ToListAsync();

            return low3SubjectsByAvgScore;
        }

    }
}
