using BonusManagementSystem.API.DB;
using Microsoft.AspNetCore.Mvc;

namespace BonusManagementSystem.API.Features.Employee
{
    
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepsoitory _employeeRepository;

        public EmployeeController(IEmployeeRepsoitory employeeRepository)
        {
                _employeeRepository = employeeRepository;
        }

        [HttpPost("api/v1/add-employee")]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest request)
        {
            var employee = await _employeeRepository.AddEmployeeAsync(request);
            return Ok(employee);
        }
        
    }
}
