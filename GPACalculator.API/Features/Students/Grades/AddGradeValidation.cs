using Microsoft.AspNetCore.Mvc;

namespace GPACalculator.API.Features.Students.Grades
{
    public class AddGradeValidation
    {
        private readonly IAddGradeRepository _addGradeRepository;

        public AddGradeValidation(IAddGradeRepository repository)
        {
            _addGradeRepository = repository;
        }

        public void Validate(AddGradeRequest? request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            if (request.StudentId <= 0)
            {
                throw new ArgumentException(nameof(request.StudentId));
            }
            if (request.SubjectId <= 0)
            {
                throw new ArgumentException(nameof(request.SubjectId));
            }

            var gradeExists = _addGradeRepository.Exists(request.StudentId, request.SubjectId);
            if (gradeExists)
            {
                throw new ArgumentException(
                    $"Grade for student {request.StudentId} for subject {request.SubjectId} already exists.");
            }
        }
    }
}
