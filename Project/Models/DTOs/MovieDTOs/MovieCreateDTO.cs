namespace Project.Models.DTOs.MovieDTOs
{
    public class MovieCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string MPARating { get; set; }
        public Guid SubscriptionId { get; set; }
    }
}
