using Project.Models.Base;

namespace Project.Models
{
    public class Movie: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public float UserScore { get; set; }
        public string MPARating { get; set; }


        /// Relations
           
        // One to Many with Subscription
        public Subscription Subscription { get; set; }
        public Guid SubscriptionId { get; set; }

        //Many to Many with User (UserMovie(Review))
        public ICollection<UserMovie_Review_>? Reviews { get; set; }
        
        
    }
}
