using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPACalculator.API.Features.Students.GetStat
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GetStatController : ControllerBase
    {
        private readonly IGetStatRepository _getStatRepository;
        public GetStatController(IGetStatRepository getStatRepository)
        {
            _getStatRepository = getStatRepository;
        }

        [HttpGet("top10Student")]
        public async Task<IActionResult> GetTop10Student()
        {
            var top10Student = await _getStatRepository.GetTop10StudentAsync();
            return Ok(top10Student);
        }

        [HttpGet("top3Subject")]
        public async Task<IActionResult> GetTop3SubjectAsync()
        {
            var top3Student = await _getStatRepository.GetTop3SubjectAsync();
            return Ok(top3Student);
        }

        [HttpGet("low3Subject")]
        public async Task<IActionResult> GetLow3SubjectAsync()
        {
            var top3Student = await _getStatRepository.GetLow3SubjectAsync();
            return Ok(top3Student);
        }
    }
}
