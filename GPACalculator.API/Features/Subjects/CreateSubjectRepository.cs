using GPACalculator.API.DB;
using GPACalculator.API.DB.Entities;

namespace GPACalculator.API.Features.Subjects
{
    public interface ICreateSubjectRepository
    {
        Task<SubjectEntity> CreateSubjectAsync(CreateSubjectRequest request);

        bool Exists(string name);

    }
    public class CreateSubjectRepository : ICreateSubjectRepository
    {
        private readonly AppDbContext _db;

        public CreateSubjectRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<SubjectEntity> CreateSubjectAsync(CreateSubjectRequest request)
        {
            var newSubject = new SubjectEntity();
            newSubject.Name = request.Name;
            newSubject.Credits = request.Credits;

            _db.Subjects.Add(newSubject);
            await _db.SaveChangesAsync();
            return newSubject;
        }

        public bool Exists(string name)
        {
            return _db.Subjects.Any(s => s.Name == name);
        }
    }
}
