namespace BonusManagementSystem.API.Features.Employee
{
    public class AddEmployeeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string RecommenderPersonalNumber { get; set; }
        public int Salary { get; set; }
        public DateTime EmployedAt { get; set; }
    }
}
