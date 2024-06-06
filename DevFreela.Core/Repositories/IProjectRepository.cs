using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task AddCommentAsync(ProjectComment comment);

        Task<int> CreateProjectAsync(Project project);

        Task<List<Project>> GetAllAsync();

        Task<Project> GetByIdAsync(int id);

        Task SaveChangesAsync();

        Task StartProjectAsync(Project project);
    }
}
