using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Template.Api.ApplicationCore.Entities;
using Template.Api.ApplicationCore.Helper;
using Template.Api.ApplicationCore.Intefaces.Repositories;

namespace Template.Api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<IEnumerable<UserEntity>> GetUsersAsync()
        {
            using var conn = new SqlConnection(Config.ConnectionString);
            var sql = "SELECT id, name, age, email FROM [user];";

            conn.Open();

            return await conn.QueryAsync<UserEntity>(sql);
        }

        public async Task<UserEntity> GetUserByIdAsync(int id)
        {
            using var conn = new SqlConnection(Config.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

            var sql = "SELECT id, name, age, email FROM [user] WHERE id = @Id;";

            conn.Open();

            return await conn.QueryFirstOrDefaultAsync<UserEntity>(sql, parameters);
        }

        public async Task CreateUserAsync(UserEntity user)
        {
            using var conn = new SqlConnection(Config.ConnectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@Name", user.Name, DbType.AnsiString, ParameterDirection.Input);
            parameters.Add("@Age", user.Age, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Email", user.Email, DbType.AnsiString, ParameterDirection.Input);

            var sql = @"INSERT INTO [user] 
            (
                name, 
                age, 
                email
            ) 
            VALUES 
            (
                @Name, 
                @Age, 
                @Email
            );";

            conn.Open();

            await conn.ExecuteAsync(sql, parameters);
        }

        public async Task UpdateUserAsync(UserEntity user)
        {
            using var conn = new SqlConnection(Config.ConnectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@Id", user.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Name", user.Name, DbType.AnsiString, ParameterDirection.Input);
            parameters.Add("@Age", user.Age, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Email", user.Email, DbType.AnsiString, ParameterDirection.Input);

            var sql = @"UPDATE [user] SET 
                name = @Name,
                age = @Age,
                email = @Email
                WHERE id = @Id;";

            conn.Open();

            await conn.ExecuteAsync(sql, parameters);
        }

        public async Task DeleteUserAsync(int id)
        {
            using var conn = new SqlConnection(Config.ConnectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

            var sql = "DELETE FROM [user] WHERE id = @Id;";

            conn.Open();

            await conn.ExecuteAsync(sql, parameters);
        }
    }
}