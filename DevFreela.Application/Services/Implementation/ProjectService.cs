using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementation
{
    public class ProjectService : IProjectService
    {

        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
            dbContext = _dbContext;
        }
        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);
            
            _dbContext.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

            _dbContext.ProjectComments.Add(comment);
        }
        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                project.Start();
            }
        }

        public int Update(UpdateProjectModel updateModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == updateModel.Id);

            project.Update(updateModel.Title, updateModel.Description, updateModel.TotalCost);

            return project.Id;
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project != null)
            {
                project.Cancel();
            }
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p =>p.Id == id);

            if (project != null)
            {
                project.Finish();
            }
        }

        public List<ProjectViewModel> GetAll()
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects.Select(p => new ProjectViewModel(p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailViewModel GetById(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            var projectDetailsViewModel = new ProjectDetailViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.StartedAt,
                project.FinishAt,
                project.TotalCost
                );
            
            return projectDetailsViewModel;

        }


    }
}
