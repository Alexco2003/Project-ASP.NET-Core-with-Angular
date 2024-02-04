using Project.Models;
using Project.Models.DTOs.MovieDTOs;

namespace Project.Services.MovieService
{
    public interface IMovieService
    {
        Task<List<MovieShownDTO>> GetTop3MoviesAsync(Guid subscriptionId);
        Task<List<MovieShownDTO>> GetMoviesByDurationAsync(Guid subscriptionId);
        Task<List<MovieShownDTO>> GetTopAllMoviesAsync();
        Task<List<System.Linq.IGrouping<string, MovieShownDTO>>> GetMoviesByMPARatingAsync(Guid subscriptionId);
        Task CreateMovie(MovieCreateDTO movie);
        Task UpdateMovie(MovieUpdateDTO movie);
        Task Delete(Guid id);
        Task<Dictionary<string, string>> GetMoviesByMPARatingAsync2(Guid subscriptionId);

    }
}
