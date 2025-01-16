using JobsApi.Dtos;
using JobsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobsApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {

            IEnumerable<UserReadDto> userReadDtos = await _userService.GetAllUsers();

            return Ok(userReadDtos);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            UserReadDto? userReadDto = await _userService.GetUserById(Id);

            if(userReadDto == null)
            {
                throw new Exception("Utilisateur introuvable");
            }

            return Ok(userReadDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreateDto userCreateDto)
        {
            UserReadDto user = await _userService.RegisterNewUser(userCreateDto);

            if (user == null)
            {
                throw new Exception("Error");
            }
            
            return Ok(user);
        }
    }
}