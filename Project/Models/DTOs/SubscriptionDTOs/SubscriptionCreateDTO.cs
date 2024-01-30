namespace Project.Models.DTOs.SubscriptionDTOs
{
    public class SubscriptionCreateDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
