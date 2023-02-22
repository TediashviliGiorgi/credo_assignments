using Microsoft.AspNetCore.Mvc;

namespace GPACalculator.API.Features.Subjects
{
    [Route("api/v1/student/subject/[controller]")]
    [ApiController]
    public class CreateSubjectController : ControllerBase
    {
        private readonly ICreateSubjectRepository _createSubjectRepository;
        private readonly CreateSubjectValidation _createSubjectValidation;

        public CreateSubjectController(ICreateSubjectRepository createSubjectRepository, CreateSubjectValidation _createSubjectValidatoin)
        {
            _createSubjectRepository= createSubjectRepository;
            _createSubjectValidation= _createSubjectValidatoin;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject(CreateSubjectRequest request)
        {
            _createSubjectValidation.Validate(request);
            var subject = _createSubjectRepository.CreateSubjectAsync(request);


            return Ok(subject);
        }
    }
}
