using AutoMapper;
using JobsApi.Data;
using JobsApi.Dtos;
using JobsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _entityFramework;
        private readonly IMapper _mapper;

        public UserService(IConfiguration config, IMapper mapper)
        {
            _entityFramework = new DataContext(config);
            _mapper = mapper;
        }

        public async Task<UserReadDto> GetUserById(int Id)
        {
            User? user = await _entityFramework.Users
                .Where(u => u.UserId == Id)
                .Include(u => u.Jobs)
                .ThenInclude(j => j.Company)
                .FirstOrDefaultAsync<User>();

            if(user == null)
            {
                throw new Exception("Utilisateur introuvable");
            }

            UserReadDto userReadDto = _mapper.Map<UserReadDto>(user);

            return userReadDto;
        }

        public async Task<IEnumerable<UserReadDto>> GetAllUsers()
        {
            IEnumerable<User> users = await _entityFramework.Users.ToListAsync<User>();

            IEnumerable<UserReadDto> userReadDtos = _mapper.Map<IEnumerable<UserReadDto>>(users);

            return userReadDtos;
        }

        public async Task<UserReadDto> RegisterNewUser(UserCreateDto userCreateDto)
        {
            User user = _mapper.Map<User>(userCreateDto);

            await _entityFramework.AddAsync(user);

            var result = await SaveUserChanges();

            if (result)
            {
                return _mapper.Map<UserReadDto>(user);
            }
            
            throw new Exception("Erreur lors de la création de l'utilisateur");
        }
        public async Task<bool> SaveUserChanges()
        {
            return await _entityFramework.SaveChangesAsync() > 0;
        }
    }
}




    

       

      
     