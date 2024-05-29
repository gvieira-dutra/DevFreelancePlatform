using Dapper;
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
        private readonly DevFreelaDbContext _dbContext;

        public StartProjectCommandHandler(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects
            .SingleOrDefault(p => p.Id == request.Id);

            if (project != null)
            {
                project.Start();

                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    var script = "UPDATE Projects" +
                    "SET Status = @status, StartedAt = @startedat" +
                    "WHERE Id = @id";

                    sqlConnection.Execute(script, new { status = project.Status, startedat = project.StartedAt, request.Id });
                }
            }
            return Task.FromResult(Unit.Value);
        }
    }
}
