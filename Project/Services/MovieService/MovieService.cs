using AutoMapper;
using Microsoft.Extensions.Hosting;
using Project.Models;
using Project.Models.DTOs.MovieDTOs;
using Project.Repositories.MovieRepository;
using Project.Repositories.SubscriptionRepository;
using Project.Repositories.UserRepository;

namespace Project.Services.MovieService
{
    public class MovieService: IMovieService
    {
        public ISubscriptionRepository _subscriptionRepository;
        public IMovieRepository _movieRepository;
        public IMapper _mapper;

        public MovieService(IMovieRepository movieRepository,
                            ISubscriptionRepository subscriptionRepository,
                            IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task CreateMovie(MovieCreateDTO movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Description = movie.Description,
                Duration = movie.Duration,
                MPARating = movie.MPARating,
                SubscriptionId = movie.SubscriptionId,
                CreatedTime = DateTime.Now
            };

            await _movieRepository.CreateAsync(_mapper.Map<Movie>(newMovie));
            await _movieRepository.SaveAsync();
        }
        public async Task Delete(Guid id)
        {
            var movie = _movieRepository.FindById(id);
            if (movie == null)
            {
                throw new Exception("Movie doesn't exist!");
            }
            _movieRepository.Delete(movie);
            await _movieRepository.SaveAsync();
        }

        public async Task UpdateMovie(MovieUpdateDTO movie)
        {
            var existingMovie = _movieRepository.FindById(movie.Id);
            if (existingMovie == null)
            {
                throw new Exception("No Movie Found!");
            }

            existingMovie.LastModifiedTime = DateTime.Now;
           
            existingMovie.UserScore = (int)movie.UserScore;

            _movieRepository.Update(_mapper.Map<Movie>(existingMovie));
            await _movieRepository.SaveAsync();
        }
        public async Task<List<MovieShownDTO>> GetTop3MoviesAsync(Guid subscriptionId)
        {
            var query = _movieRepository.GetTop3MoviesAsync(subscriptionId);
            return _mapper.Map<List<MovieShownDTO>>(await query);
            
        }
        public async Task<List<MovieShownDTO>> GetMoviesByDurationAsync(Guid subscriptionId)
        {
            var query = _movieRepository.GetMoviesByDurationAsync(subscriptionId);
            return _mapper.Map<List<MovieShownDTO>>(await query);
        }
        public async Task<List<MovieShownDTO>> GetTopAllMoviesAsync()
        {
            var query = _movieRepository.GetTopAllMoviesAsync();
            return _mapper.Map<List<MovieShownDTO>>(await query);
        }
        public async Task<List<System.Linq.IGrouping<string, MovieShownDTO>>> GetMoviesByMPARatingAsync(Guid subscriptionId)
        {
            var query = _movieRepository.GetMoviesByMPARatingAsync(subscriptionId);
            return _mapper.Map<List<System.Linq.IGrouping<string, MovieShownDTO>>>(await query);
        }
    }
}
