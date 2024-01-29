using Microsoft.Extensions.Hosting;
using Project.Models;
using Project.Repositories.GenericRepository;

namespace Project.Repositories.MovieRepository
{
    public interface IMovieRepository: IGenericRepository<Movie>
    {
        Task<List<Movie>> GetTop3MoviesAsync(Guid subscriptionId);
        Task<List<Movie>> GetMoviesByDurationAsync(Guid subscriptionId);
        Task<List<Movie>> GetTopAllMoviesAsync();
        Task<List<System.Linq.IGrouping<string, Movie>>> GetMoviesByMPARatingAsync(Guid subscriptionId);


    }
}
