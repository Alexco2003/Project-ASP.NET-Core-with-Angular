namespace Project.Models.DTOs.SubscriptionDTOs
{
    public class SubscriptionUpdateDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
