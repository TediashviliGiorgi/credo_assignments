using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPACalculator.API.Features.Students.RegisterStudent
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RegisterStudentController : ControllerBase
    {
        private readonly IRegisterStudentRepository _registerStudentRepository;
        private readonly RegisterStudentValidation _validation;

        public RegisterStudentController(IRegisterStudentRepository registerStudentRepository, RegisterStudentValidation validation)
        {
            _registerStudentRepository = registerStudentRepository;
            _validation = validation;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisterStudentRequest request)
        {
            _validation.Validate(request);
            var student = await _registerStudentRepository.RegisterStudentAsync(request);
            return Ok(student);
        }
    }
}
