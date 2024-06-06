using Dapper;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly string _connectionString;
        private readonly IProjectRepository _projectRepository;

        public StartProjectCommandHandler(IConfiguration configuration, IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project != null)
            {
                project.Start();

                await _projectRepository.StartProjectAsync(project);
            }
            return Unit.Value;
        }
    }
}
