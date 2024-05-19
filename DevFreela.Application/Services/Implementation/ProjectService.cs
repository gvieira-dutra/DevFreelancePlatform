using Dapper;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly string _connectionString;
        private readonly DevFreelaDbContext _dbContext;

        public ProjectService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);

            _dbContext.Projects
                      .Add(project);

            _dbContext.SaveChanges();

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

            _dbContext.ProjectComments
                      .Add(comment);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects
                .SingleOrDefault(p => p.Id == id);

            if (project != null)
            {
                project.Cancel();
            }

            _dbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects
                .SingleOrDefault(p => p.Id == id);

            if (project != null)
            {
                project.Finish();
            }

            _dbContext.SaveChanges();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToList();

            return projectsViewModel;
        }

        public ProjectDetailViewModel GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefault(p => p.Id == id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.StartedAt,
                project.FinishAt,
                project.TotalCost,
                project.Client.FullName,
                project.Freelancer.FullName
                );

            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects
            .SingleOrDefault(p => p.Id == id);

            if (project != null)
            {
                project.Start();

                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    var script = "UPDATE Projects" +
                    "SET Status = @status, StartedAt = @startedat" +
                    "WHERE Id = @id";

                    sqlConnection.Execute(script, new { status = project.Status, startedat = project.StartedAt, id });
                }
            }
        }

        public int Update(UpdateProjectInputModel updateModel)
        {
            var project = _dbContext.Projects
                .SingleOrDefault(p => p.Id == updateModel.Id);

            project
                .Update(updateModel.Title, updateModel.Description, updateModel.TotalCost);

            _dbContext.SaveChanges();

            return project.Id;
        }
    }
}
