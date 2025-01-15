using JobsApi.Data;
using JobsApi.Dtos;
using JobsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        DataContext _entityFramework;

        public UserController(IConfiguration config)
        {
            _entityFramework = new DataContext(config);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            IEnumerable<User> users = await _entityFramework.Users.ToListAsync<User>();

            return Ok(users);
        }

        [HttpGet("users/{Id:int}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            User? user = await _entityFramework.Users
                .Where(u => u.UserId == Id)
                .FirstOrDefaultAsync<User>();

            if(user == null)
            {
                throw new Exception("Error");
            }

            return Ok(user);
        }

        [HttpPost("users")]
        public async Task<IActionResult> AddUser(UserCreateDto userCreateDto)
        {
            User user = new User();

            user.FirstName = userCreateDto.FirstName;
            user.LastName = userCreateDto.LastName;
            user.DateOfBirth = userCreateDto.DateOfBirth;

            await _entityFramework.AddAsync(user);

            if (await _entityFramework.SaveChangesAsync() > 0)
            {
                return Ok(user);
            }
            
            throw new Exception("Error");
        }
    }
}