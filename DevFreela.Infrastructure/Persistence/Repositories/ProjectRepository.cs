using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
        : IProjectRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("DevFreelaCs");
        private readonly DevFreelaDbContext _dbContext = dbContext;

        public async Task AddCommentAsync(ProjectComment comment)
        {
            await _dbContext.ProjectComments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CreateProjectAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();

            return project.Id;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task StartProjectAsync(Project project)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Projects" +
                "SET Status = @status, StartedAt = @startedat" +
                "WHERE Id = @id";

                await sqlConnection.ExecuteAsync(script, new { status = project.Status, startedat = project.StartedAt, project.Id });
            }
        }
    }
}
