using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Api.ApplicationCore.Dto;

namespace Template.Api.ApplicationCore.Intefaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task CreateUserAsync(UserBaseDto user);
        Task UpdateUserAsync(int id, UserBaseDto user);
        Task DeleteUserAsync(int id);
    }
}