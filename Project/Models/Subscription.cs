using Project.Models.Base;

namespace Project.Models
{
    public class Subscription: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        
        /// Relations
        
        //One to One with User
        public User User { get; set; }
        public Guid UserId { get; set; }

        //One to Many with Movie
        public ICollection<Movie>? Movies { get; set; }
    }
}
