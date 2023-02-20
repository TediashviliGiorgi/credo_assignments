using GPACalculator.API.DB;
using GPACalculator.API.DB.Entities;

namespace GPACalculator.API.Features.Students.RegisterStudent
{
    public interface IRegisterStudentRepository
    {
        Task<StudentEntity> RegisterStudentAsync(RegisterStudentRequest request);
        bool ExistsWithPersonalNumber(string personalNumber);
    }
    public class RegisterStudentRepository : IRegisterStudentRepository
    {
        private readonly AppDbContext _db;

        public RegisterStudentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<StudentEntity> RegisterStudentAsync(RegisterStudentRequest request)
        {
            var newStudent = new StudentEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PersonalNumber = request.PersonalNumber,
                Course = request.Course,

            };
            _db.Students.Add(newStudent);
            await _db.SaveChangesAsync();

            return newStudent;
        }

        public bool ExistsWithPersonalNumber(string personalNumber)
        {
            return _db.Students.Any(S => S.PersonalNumber == personalNumber);
        }
    }
}
