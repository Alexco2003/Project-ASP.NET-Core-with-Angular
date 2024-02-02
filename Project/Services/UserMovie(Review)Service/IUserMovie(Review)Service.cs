using Project.Models.DTOs.UserMovie_Review_DTOs;
using System.Threading.Tasks;

namespace Project.Services.UserMovie_Review_Service
{
    public interface IUserMovie_Review_Service
    {
        Task AddReview(UserMovie_Review_Create review);
        Task UpdateReview(UserMovie_Review_Update review);
        Task DeleteReview(Guid id);
        Task<List<UserMovie_Review_Formatted2DTO>> GetReviewsOfMovie(Guid id);
        Task<List<UserMovie_Review_FormattedDTO>> GetReviewsOfUser(Guid id);
    }
}
