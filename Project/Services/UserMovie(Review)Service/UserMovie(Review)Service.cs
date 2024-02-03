using AutoMapper;
using Project.Models;
using Project.Models.DTOs.UserMovie_Review_DTOs;
using Project.Repositories.MovieRepository;
using Project.Repositories.UserMovie_Review_Repository;
using Project.Repositories.UserRepository;

namespace Project.Services.UserMovie_Review_Service
{
    public class UserMovie_Review_Service : IUserMovie_Review_Service
    {
        public IUserMovie_Review_Repository _reviewRepository;
        public IUserRepository _userRepository;
        public IMovieRepository _movieRepository;
        public IMapper _mapper;

        public UserMovie_Review_Service(IUserMovie_Review_Repository reviewRepository,
                               IUserRepository userRepository,
                               IMovieRepository movieRepository,
                               IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }

        public async Task AddReview(UserMovie_Review_Create review)
        {
            var user = _userRepository.GetUserById(review.UserId);
            if (user == null)
            {
                throw new Exception("User not found!");
            }

            var movie = _movieRepository.FindById(review.MovieId);
            if (movie == null)
            {
                throw new Exception("Movie not found!");
            }

            await _reviewRepository.CreateAsync(_mapper.Map<UserMovie_Review_>(review));
            await _reviewRepository.SaveAsync();

            
        }

        public async Task DeleteReview(Guid id)
        {
            var review = _reviewRepository.FindById(id);
            if (review == null)
            {
                throw new Exception("Review not found!");
            }
            _reviewRepository.Delete(review);
            await _reviewRepository.SaveAsync();

           
        }

        public async Task UpdateReview(UserMovie_Review_Update review)
        {
            var existingReview = _reviewRepository.FindById(review.Id);
            if (existingReview == null)
            {
                throw new Exception("Review not found!");
            }

            existingReview.UserScore = (float)review.UserScore;

            _reviewRepository.Update(_mapper.Map<UserMovie_Review_>(existingReview));
            await _reviewRepository.SaveAsync();


        }

        public async Task<List<UserMovie_Review_Formatted2DTO>> GetReviewsOfMovie(Guid id)
        {
            return await _reviewRepository.GetReviewsOfMovie(id);
         
        }

        public async Task<List<UserMovie_Review_FormattedDTO>> GetReviewsOfUser(Guid id)
        {
            return await _reviewRepository.GetReviewsOfUser(id);
       
        }

        
    }
}
