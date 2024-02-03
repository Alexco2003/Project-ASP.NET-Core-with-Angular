using Project.Models;
using Project.Models.DTOs.UserMovie_Review_DTOs;
using Project.Repositories.GenericRepository;

namespace Project.Repositories.UserMovie_Review_Repository
{
    public interface IUserMovie_Review_Repository :IGenericRepository<UserMovie_Review_>
    {
       
        Task<List<UserMovie_Review_Formatted2DTO>> GetReviewsOfMovie(Guid id);
        Task<List<UserMovie_Review_FormattedDTO>> GetReviewsOfUser(Guid id);
      
    }
}
