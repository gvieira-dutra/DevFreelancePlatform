using Dapper;
using DevFreela.Core.DTO;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;
        private readonly DevFreelaDbContext _dbContext;

        public SkillRepository(IConfiguration configuration, DevFreelaDbContext dbContext)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
            _dbContext = dbContext;
        }

        public async Task<List<SkillDTO>> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Description " +
                             "FROM Skills";

                var skills = await sqlConnection.QueryAsync<SkillDTO>(script);

                return skills.ToList();
            }
        }
    }
}
