namespace Project.Models.DTOs.UserMovie_Review_DTOs
{
    public class UserMovie_Review_Create
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public string Review { get; set; }
        public float UserScore { get; set; }
    }
}
