using Project.Data;
using Project.Models;

namespace Project.Helpers.Seeders
{
    public class UserMovie_Review_Seeder
    {
        public readonly ProjectContext _context;

        public UserMovie_Review_Seeder(ProjectContext context)
        {
            _context = context;
        }
        public void SeedInitialUserMovie_Reviews_()
        {
            if (!_context.Reviews.Any())
            {
                var user_movie_reviews = new List<UserMovie_Review_>()
                {
                    new UserMovie_Review_()
                    {
                        UserId = new Guid("A777C9F3-6811-4BB6-BB20-352BDD9F00A1"),
                        MovieId = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a2"),
                        Review = "This movie is great!",
                        UserScore = 8.5f
                    },
                    new UserMovie_Review_()
                    {
                        UserId = new Guid("A777C9F3-6811-4BB6-BB20-352BDD9F00A1"),
                        MovieId = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a3"),
                        Review = "This movie is amazing!",
       
                        UserScore = 9.3f
                    },


                   
                    new UserMovie_Review_()
                    {
                        UserId = new Guid("AEB1D17A-F966-4089-A5B8-F28CE98D4E28"),
                        UserScore = 5.3f,
                        Review = "This movie is shit!",
                
                        MovieId = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a6")
                    },
                    new UserMovie_Review_()
                    {
                        UserId = new Guid("AEB1D17A-F966-4089-A5B8-F28CE98D4E28"),
                        UserScore = 7.6f,
                        Review ="This movie is meh!",
                        
                        MovieId = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a9")
                    },



                     new UserMovie_Review_()
                    {
                        UserId = new Guid("3CC80F65-2FC3-407D-B9D5-7BE0B1439A08"),
                        UserScore = 6.7f,
                        Review = "I hate that the script is not well made.",
                        
                        MovieId = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a2")
                    },
                     new UserMovie_Review_()
                    {
                        UserId = new Guid("3CC80F65-2FC3-407D-B9D5-7BE0B1439A08"),
                        UserScore = 3.3f,
                        Review = "I hate the character development.",

                        MovieId = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a8")
                    }

                };

                _context.Reviews.AddRange(user_movie_reviews);
                _context.SaveChanges();
            }
        }
    }
}
