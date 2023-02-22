using Microsoft.AspNetCore.Mvc;

namespace GPACalculator.API.Features.Students.CalculateGPA
{
    [Route("api/v1/student/{studentId}/calculateGPA")]
    [ApiController]
    public class CalculateGPAController : ControllerBase
    {
        private readonly ICalculateGpaRepository _calculatrGpaRepository;
        public CalculateGPAController(ICalculateGpaRepository calculatrGpaRepository)
        {
            _calculatrGpaRepository = calculatrGpaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateGpa(int studentId)
        {
            var studentGrades = await _calculatrGpaRepository.GetStudentGradesAsync(studentId);
            var calculator = new GPACalculator();
            var gpa = calculator.Calculate(studentGrades);

            return Ok(gpa);
        }
    }
}
