using Microsoft.Extensions.Hosting;
using Project.Models;
using Project.Models.DTOs.MovieDTOs;
using Project.Repositories.GenericRepository;

namespace Project.Repositories.MovieRepository
{
    public interface IMovieRepository: IGenericRepository<Movie>
    {
        Task<List<Movie>> GetTop3MoviesAsync(Guid subscriptionId);
        Task<List<Movie>> GetMoviesByDurationAsync(Guid subscriptionId);
        Task<List<Movie>> GetTopAllMoviesAsync();
        Task<List<System.Linq.IGrouping<string, Movie>>> GetMoviesByMPARatingAsync(Guid subscriptionId);
        Task<Dictionary<string, string>> GetMoviesByMPARatingAsync2(Guid subscriptionId);

    }
}
