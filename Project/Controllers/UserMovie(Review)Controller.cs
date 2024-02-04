using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models.DTOs.UserMovie_Review_DTOs;
using Project.Models.Responses;
using Project.Services.UserMovie_Review_Service;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMovie_Review_Controller : ControllerBase
    { 
        private readonly IUserMovie_Review_Service _reviewService;

        public UserMovie_Review_Controller(IUserMovie_Review_Service reviewService)
        {
            _reviewService = reviewService;
        }

        
        [HttpPost("CreateReview")]
        public async Task<IActionResult> AddReview([FromBody] UserMovie_Review_Create review)
        {
            try
            {
                await _reviewService.AddReview(review);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete("DeleteReview")]
        public async Task<IActionResult> DeleteReview([FromBody] Guid id)
        {
            try
            {
                await _reviewService.DeleteReview(id);
                return Ok(new ErrorResponse()
                {
                    StatusCode = 200,
                    Message = "Review was deleted successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpPatch("UpdateReview")]
        public async Task<IActionResult> UpdateReview([FromBody] UserMovie_Review_Update review)
        {
            try
            {
                await _reviewService.UpdateReview(review);
                return Ok(new ErrorResponse()
                {
                    StatusCode = 200,
                    Message = "Review was updated successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("GetReviewsOfMovie")]
        public async Task<IActionResult> GetReviewsOfMovie(Guid movieId)
        {
            try
            {
                return Ok(await _reviewService.GetReviewsOfMovie(movieId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetReviewsOfUser")]
        public async Task<IActionResult> GetReviewsOfUser(Guid userId)
        {
            try
            {
                return Ok(await _reviewService.GetReviewsOfUser(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
