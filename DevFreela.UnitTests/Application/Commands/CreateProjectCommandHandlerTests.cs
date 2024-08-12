using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            //Arrange 
            var projectRepositoryMoq = new Mock<IProjectRepository>();

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Test Project",
                Description = "Description",
                TotalCost = 4000,
                IdClient = 1,
                IdFreelancer = 2,
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMoq.Object);

            //Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);

            projectRepositoryMoq.Verify(pr => pr.CreateProjectAsync(It.IsAny<Project>()), Times.Once);
        }

        [Fact]
        public async Task RepositoryThrowsException_Executed_ThrowsException()
        {
            // Arrange
            var projectRepositoryMoq = new Mock<IProjectRepository>();
            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Test Project",
                Description = "Description",
                TotalCost = 4000,
                IdClient = 1,
                IdFreelancer = 2,
            };

            projectRepositoryMoq.Setup(pr => pr.CreateProjectAsync(It.IsAny<Project>())).ThrowsAsync(new Exception("Database error"));

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMoq.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken()));
        }

        [Fact]
        public async Task ValidData_Executed_CreatesProject()
        {
            // Arrange
            var projectRepositoryMoq = new Mock<IProjectRepository>();
            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Valid Project",
                Description = "Valid Description",
                TotalCost = 5000,
                IdClient = 1,
                IdFreelancer = 2,
            };

            var expectedProjectId = 1;
            projectRepositoryMoq.Setup(pr => pr.CreateProjectAsync(It.IsAny<Project>())).ReturnsAsync(expectedProjectId);

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMoq.Object);

            // Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            Assert.Equal(expectedProjectId, id);
            projectRepositoryMoq.Verify(pr => pr.CreateProjectAsync(It.Is<Project>(p =>
                p.Title == createProjectCommand.Title &&
                p.Description == createProjectCommand.Description &&
                p.TotalCost == createProjectCommand.TotalCost &&
                p.IdClient == createProjectCommand.IdClient &&
                p.IdFreelancer == createProjectCommand.IdFreelancer)), Times.Once);
        }

        [Fact]
        public async Task MinimumRequiredData_Executed_ReturnsProjectId()
        {
            // Arrange
            var projectRepositoryMoq = new Mock<IProjectRepository>();
            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Minimum Data",
                Description = "Minimal Description",
                TotalCost = 1000,
                IdClient = 1,
                IdFreelancer = 1,
            };

            var expectedProjectId = 1;
            projectRepositoryMoq.Setup(pr => pr.CreateProjectAsync(It.IsAny<Project>())).ReturnsAsync(expectedProjectId);

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMoq.Object);

            // Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            Assert.Equal(expectedProjectId, id);
            projectRepositoryMoq.Verify(pr => pr.CreateProjectAsync(It.Is<Project>(p =>
                p.Title == createProjectCommand.Title &&
                p.Description == createProjectCommand.Description &&
                p.TotalCost == createProjectCommand.TotalCost &&
                p.IdClient == createProjectCommand.IdClient &&
                p.IdFreelancer == createProjectCommand.IdFreelancer)), Times.Once);
        }


    }
}
