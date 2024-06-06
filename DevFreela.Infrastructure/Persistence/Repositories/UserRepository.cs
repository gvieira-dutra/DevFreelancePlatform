using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository(DevFreelaDbContext dbContext)
        : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext = dbContext;

        public async Task<int> CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
