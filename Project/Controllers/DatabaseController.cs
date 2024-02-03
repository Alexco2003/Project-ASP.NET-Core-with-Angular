using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models.DTOs.UserDTOs;
using Project.Services.UserService;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly ProjectContext _ProjectContext;

        // Getters
        public DatabaseController(ProjectContext ProjectContext)
        {
            _ProjectContext = ProjectContext;
        }

        [HttpGet("User")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _ProjectContext.Users.ToListAsync());
        }

        [HttpGet("Movie")]
        public async Task<IActionResult> GetReacts()
        {
            return Ok(await _ProjectContext.Movies.ToListAsync());
        }

        [HttpGet("Subscription")]
        public async Task<IActionResult> GetPosts()
        {
            return Ok(await _ProjectContext.Subscriptions.ToListAsync());
        }

        [HttpGet("Review")]
        public async Task<IActionResult> GetComments()
        {
            return Ok(await _ProjectContext.Reviews.ToListAsync());
        }

        [HttpGet("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _ProjectContext.Roles.ToListAsync());
        }

       
       
       
    }
}
