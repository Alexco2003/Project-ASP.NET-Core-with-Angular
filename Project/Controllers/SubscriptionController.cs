using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models.DTOs.SubscriptionDTOs;
using Project.Models.Responses;
using Project.Services.SubscriptionService;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
       
            private readonly ISubscriptionService _SubscriptionService;

            public SubscriptionController(ISubscriptionService SubscriptionService)
            {
                _SubscriptionService = SubscriptionService;
            }

            [HttpPost("CreateSubscription")]
            public async Task<IActionResult> CreateSubscription(SubscriptionCreateDTO Subscription)
            {
                try
                {
                    await _SubscriptionService.CreateSubscription(Subscription);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpGet("GetSubscription")]
            public async Task<IActionResult> GetSubscriptionByUsername(string username)
            {
                try
                {
                    return Ok(await _SubscriptionService.GetSubscriptionByUsername(username));
                }
                catch (Exception ex)
                {
                    return BadRequest(new ErrorResponse()
                    {
                        StatusCode = 400,
                        Message = ex.Message
                    });
                }
            }

            [HttpPatch("UpdateSubscription")]
            public async Task<IActionResult> UpdateSubscription([FromBody] SubscriptionUpdateDTO Subscription)
            {
                try
                {
                    await _SubscriptionService.UpdateSubscription(Subscription);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(new ErrorResponse()
                    {
                        StatusCode = 400,
                        Message = ex.Message
                    });
                }
            }
        }
}
