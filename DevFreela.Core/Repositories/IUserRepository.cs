using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<int> CreateUserAsync(User user);

        Task<User> GetUserByIdAsync(int id);

        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
