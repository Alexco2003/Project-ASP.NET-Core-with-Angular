using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Project.Data;
using Project.Models;
using Project.Repositories.GenericRepository;

namespace Project.Repositories.MovieRepository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ProjectContext context) : base(context) { }

        public async Task<List<Movie>> GetTop3MoviesAsync(Guid subscriptionId)
        {
            var query = _table.Where(s => s.SubscriptionId == subscriptionId)
                              .GroupBy(s => s.Id)
                              .SelectMany(s => s)
                              .OrderByDescending(s => s.UserScore)
                              .Take(3); 

            return await query.ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesByDurationAsync(Guid subscriptionId)
        {
            var query = _table.Where(s => s.SubscriptionId == subscriptionId)
                              .GroupBy(s => s.Id)
                              .SelectMany(s => s)
                              .OrderBy(s => s.Duration);

            return await query.ToListAsync();
        }

        public Task<List<Movie>> GetTopAllMoviesAsync()
        {
            var query = _table.OrderByDescending(s => s.UserScore);
                              
            return query.ToListAsync();
        }
        public Task<List<System.Linq.IGrouping<string, Movie>>> GetMoviesByMPARatingAsync(Guid subscriptionId)
        {
            var query = _table.Where(s => s.SubscriptionId == subscriptionId)
                              .GroupBy(s => s.MPARating);
            
            return query.ToListAsync();
        }


    }
}
   
