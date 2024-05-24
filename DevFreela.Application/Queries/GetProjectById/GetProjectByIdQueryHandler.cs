using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetProjectByIdQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProjectDetailViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects
               .Include(p => p.Client)
               .Include(p => p.Freelancer)
               .SingleOrDefaultAsync(p => p.Id == request.Id);
        
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
