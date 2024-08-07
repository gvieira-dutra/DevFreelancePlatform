using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateCommentCommandHandlerTests
    {
        [Fact]
        public async Task ProjectHasNoComments_Execute_ProjectHasComments()
        {
            // Arrange
            var projectRepositoryMoq = new Mock<IProjectRepository>();

            var project = new Project("Test Project", "Description", 1, 2, 4000);
            int projectId = 1; 

            projectRepositoryMoq.Setup(pr => 
            pr.CreateProjectAsync(It.IsAny<Project>()))
                .ReturnsAsync(projectId);
            
            projectRepositoryMoq.Setup(pr => 
            pr.GetByIdAsync(projectId))
                .ReturnsAsync(project);

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Test Project",
                Description = "Description",
                TotalCost = 4000,
                IdClient = 1,
                IdFreelancer = 2,
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMoq.Object);

            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            var createCommentCommand = new CreateCommentCommand
            {
                Content = "This is my comment",
                IdProject = id,
                IdUser = 2,
            };

            var createCommentCommandHandler = new CreateCommentCommandHandler(projectRepositoryMoq.Object);

            // Act
            await createCommentCommandHandler.Handle(createCommentCommand, new CancellationToken());

            // Assert
            projectRepositoryMoq.Verify(pr => pr.AddCommentAsync(It.Is<ProjectComment>(c =>
                c.Content == createCommentCommand.Content &&
                c.IdProject == createCommentCommand.IdProject &&
                c.IdUser == createCommentCommand.IdUser)),
                Times.Once);

        }

        [Fact]
        public async Task CreateEmptyComment_Execute_ThrowsException()
        {
            // Arrange
            var projectRepositoryMoq = new Mock<IProjectRepository>();
            var createCommentCommand = new CreateCommentCommand
            {
                Content = null,
                IdProject = 1,
                IdUser = 1,
            };

            var createCommentCommandHandler = new CreateCommentCommandHandler(projectRepositoryMoq.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => createCommentCommandHandler.Handle(createCommentCommand, new CancellationToken()));
        }

        [Fact]
        public async Task InvalidProjectId_Execute_ThrowsException()
        {
            // Arrange
            var projectRepositoryMoq = new Mock<IProjectRepository>();
            var createCommentCommand = new CreateCommentCommand
            {
                Content = "Valid comment",
                IdProject = 999, 
                IdUser = 1,
            };

            var createCommentCommandHandler = new CreateCommentCommandHandler(projectRepositoryMoq.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => createCommentCommandHandler.Handle(createCommentCommand, new CancellationToken()));
        }

    }
}
