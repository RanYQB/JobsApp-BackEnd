using AutoMapper;
using JobsApi.Data;
using JobsApi.Dtos;
using JobsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _entityFramework;

        public UserController(IConfiguration config, IMapper mapper)
        {
            _entityFramework = new DataContext(config);
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            IEnumerable<User> users = await _entityFramework.Users.ToListAsync<User>();

            IEnumerable<UserReadDto> userReadDtos = _mapper.Map<IEnumerable<UserReadDto>>(users);

            return Ok(userReadDtos);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            User? user = await _entityFramework.Users
                .Where(u => u.UserId == Id)
                .FirstOrDefaultAsync<User>();

            if(user == null)
            {
                throw new Exception("Error");
            }

            UserReadDto userReadDto = _mapper.Map<UserReadDto>(user);

            return Ok(userReadDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreateDto userCreateDto)
        {
            User user = _mapper.Map<User>(userCreateDto);

            await _entityFramework.AddAsync(user);

            if (await _entityFramework.SaveChangesAsync() > 0)
            {
                return Ok(user);
            }
            
            throw new Exception("Error");
        }
    }
}