namespace BonusManagementSystem.API.DB.Entities
{
    public class BonusEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get;set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
