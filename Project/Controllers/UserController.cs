using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Models.DTOs;
using Project.Models.DTOs.UserDTOs;
using Project.Models.Responses;
using Project.Repositories.UserRepository;
using Project.Services.UserService;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                return Ok(await _userService.GetUserById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("GetUserByUsername")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            try
            {
                return Ok(await _userService.GetUserByUsername(username));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,

                    Message = ex.Message
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDTO signUpDTO)
        {
            try
            {
                await _userService.SignUp(signUpDTO);
                return Ok(new ErrorResponse()
                {
                    StatusCode = 200,
                    Message = "SignUp successful"
                });
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

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            try
            {
                return Ok(new LoginResponseDTO()
                {
                    Id = await _userService.Login(login)
                });
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,
                    Message = exception.Message
                });
            }
        }

        [Authorize]
        [HttpPost("LogOut")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _userService.Logout();
                return Ok(new ErrorResponse()
                {
                    StatusCode = 200,
                    Message = "Logout Successful"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,
                    Message = ex.Message
                });
            }
        }

        [HttpPatch("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDTO user)
        {
            try
            {
                await _userService.Update(user);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,
                    Message = exception.Message
                });
            }
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userService.Delete(id);
                return Ok(new ErrorResponse()
                {
                    StatusCode = 200,
                    Message = "User was deleted successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,
                    Message = ex.Message
                });
            }
        }

         [HttpPost("CreateUser")]
         public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO user)
         {
             try
             {
                 var newUser = await _userService.CreateAsync(user);
                 return CreatedAtAction("CreateUser", newUser);
             }
             catch (Exception e)
             {
                 return BadRequest(e.Message);
             }


         }



    }
}
