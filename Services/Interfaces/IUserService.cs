using JobsApi.Dtos;

namespace JobsApi.Services
{
    public interface IUserService
    {
        Task<UserReadDto> GetUserById(int Id);
        Task<IEnumerable<UserReadDto>> GetAllUsers();
        Task<UserReadDto> RegisterNewUser(UserCreateDto userCreateDto);
        Task<bool> SaveUserChanges();
    }
}
