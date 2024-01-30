using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.DTOs.UserMovie_Review_DTOs;
using Project.Repositories.GenericRepository;

namespace Project.Repositories.UserMovie_Review_Repository
{
    public class UserMovie_Review_Repository: GenericRepository<UserMovie_Review_>, IUserMovie_Review_Repository
    {
        public UserMovie_Review_Repository(ProjectContext context) : base(context) { }
        public async Task<List<UserMovie_Review_Formatted2DTO>> GetReviewsOfMovie(Guid id)
        {
            return await _table.Where(r => r.MovieId == id)
                .Include(r => r.User)
                .Select(r => new UserMovie_Review_Formatted2DTO()
            {
                
                MovieTitle = r.Movie.Name,
                Review = r.Review,
                UserName = r.User.FirstName + " " + r.User.LastName,
                Age = r.User.Age,
                UserScore = r.UserScore
                
            }).ToListAsync();
        }

        public async Task<List<UserMovie_Review_FormattedDTO>> GetReviewsOfUser(Guid id)
        {
            var query = from review in _table
                        join user in _ProjectContext.Users on review.UserId equals user.Id
                        join movie in _ProjectContext.Movies on review.MovieId equals movie.Id
                        where review.UserId == id
                        select new UserMovie_Review_FormattedDTO()
                        {
                            UserName = user.FirstName + " " + user.LastName,
                            MovieTitle = movie.Name,
                            Duration = movie.Duration,
                            Review = review.Review,
                            UserScore = review.UserScore
                            
                        };

            return await query.ToListAsync();
        }

    }
}
