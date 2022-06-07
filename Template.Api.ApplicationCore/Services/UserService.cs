using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Api.ApplicationCore.Dto;
using Template.Api.ApplicationCore.Entities;
using Template.Api.ApplicationCore.Intefaces.Repositories;
using Template.Api.ApplicationCore.Intefaces.Services;

namespace Template.Api.ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            return (await _userRepository.GetUsersAsync())
                .Select(u => new UserDto()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Age = u.Age,
                    Email = u.Email
                });
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var result = await _userRepository.GetUserByIdAsync(id);
            if (result is null)
                return null;

            return new UserDto()
            {
                Id = result.Id,
                Name = result.Name,
                Age = result.Age,
                Email = result.Email
            };
        }

        public async Task CreateUserAsync(UserBaseDto user)
        {
            await _userRepository.CreateUserAsync(new UserEntity
            {
                Name = user.Name,
                Age = user.Age,
                Email = user.Email
            });
        }

        public async Task UpdateUserAsync(int id, UserBaseDto user)
        {
            var result = await GetUserByIdAsync(id);
            if (result is null)
                return;

            await _userRepository.UpdateUserAsync(new UserEntity()
            {
                Id = id,
                Name = user.Name,
                Age = user.Age,
                Email = user.Email
            });
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user is null)
                return;

            await _userRepository.DeleteUserAsync(id);
        }
    }
}