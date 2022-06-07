using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Api.ApplicationCore.Entities;

namespace Template.Api.ApplicationCore.Intefaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetUsersAsync();
        Task<UserEntity> GetUserByIdAsync(int id);
        Task CreateUserAsync(UserEntity user);
        Task UpdateUserAsync(UserEntity user);
        Task DeleteUserAsync(int id);
    }
}