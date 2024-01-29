using Project.Models.Base;

namespace Project.Models
{
    public class UserMovie_Review_ : BaseEntity
    {
        public int UserScore { get; set; }
        public string Review { get; set; }
        
        /// Relations
              
        // Many to Many with User (UserMovie(Review))
        public User User { get; set; }
        public Guid UserId { get; set; }

        // Many to Many with User (UserMovie(Review))
        public Movie Movie { get; set; }
        public Guid MovieId { get; set; }
    }
}
