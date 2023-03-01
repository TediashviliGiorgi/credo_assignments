using BonusManagementSystem.API.DB;
using BonusManagementSystem.API.DB.Entities;

namespace BonusManagementSystem.API.Features.Employee
{
    public interface IEmployeeRepsoitory
    {
        Task<EmployeeEntity> AddEmployeeAsync(AddEmployeeRequest request);
    }
    public class EmployeeRepository : IEmployeeRepsoitory
    {
        private readonly AppDbContext _db;

        public EmployeeRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<EmployeeEntity> AddEmployeeAsync(AddEmployeeRequest request)
        {
            var newEmployee = new EmployeeEntity();

            newEmployee.FirstName = request.FirstName;
            newEmployee.LastName = request.LastName;
            newEmployee.PersonalNumber = request.PersonalNumber;
            newEmployee.RecommenderPersonalNumber = request.RecommenderPersonalNumber;
            newEmployee.Salary = request.Salary;
            newEmployee.EmployedAt= DateTime.Now;
            await _db.Employees.AddAsync(newEmployee);
            await _db.SaveChangesAsync();

            return newEmployee;
        }
    }

}
