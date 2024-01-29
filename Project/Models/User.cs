using Microsoft.AspNetCore.Identity;

namespace Project.Models
{
    public class User: IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Budget { get; set; }

        /// Relations

        // One to One with Subscription
        public Subscription? Subscription { get; set; }

        // Many to Many with Movie (UserMovie(Review))
        public ICollection<UserMovie_Review_>? Reviews { get; set; }


    }
}
