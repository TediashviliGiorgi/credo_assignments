using Microsoft.AspNetCore.Mvc;

namespace GPACalculator.API.Features.Students.Grades
{
    [Route("api/v1/student/add-grade")]
    [ApiController]
    public class AddGradeController : ControllerBase
    {
        private readonly IAddGradeRepository _addGradeRepository;
        private readonly AddGradeValidation _validation;

        public AddGradeController(IAddGradeRepository addGradeRepository, AddGradeValidation validation)
        {
            _addGradeRepository = addGradeRepository;
            _validation = validation;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentGrade(AddGradeRequest request)
        {
            var grade = await _addGradeRepository.AddGradeAsync(request);
            return Ok(grade);
        }
    }
}
