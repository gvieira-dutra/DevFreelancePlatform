using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserId()
        {
            // Arrange
            var userRepositoryMoq = new Mock<IUserRepository>();
            var userAuthServiceMoq = new Mock<IAuthService>();

            var createUserCommand = new CreateUserCommand
            {
                FullName = "User Name",
                Email = "user@mail.com",
                Password = "123456",
                BirthDate = DateTime.Now.AddYears(-40),
                Role = "client"
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMoq.Object, userAuthServiceMoq.Object);

        }
    }
}
