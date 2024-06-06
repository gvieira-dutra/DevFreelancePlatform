using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        : IRequestHandler<GetProjectByIdQuery, ProjectDetailViewModel>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<ProjectDetailViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

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
    }
}
