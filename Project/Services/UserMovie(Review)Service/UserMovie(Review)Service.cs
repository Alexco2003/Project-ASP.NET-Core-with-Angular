using Project.Models.DTOs.UserMovie_Review_DTOs;
using Project.Repositories.UserMovie_Review_Repository;

namespace Project.Services.UserMovie_Review_Service
{
    public class UserMovie_Review_Service : IUserMovie_Review_Service
    {
        public Task AddReview(UserMovie_Review_Create review)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReview(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserMovie_Review_Formatted2DTO>> GetReviewsOfMovie(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserMovie_Review_FormattedDTO>> GetReviewsOfUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReview(UserMovie_Review_Update review)
        {
            throw new NotImplementedException();
        }
    }
}
