using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjecStartWorks()
        {
            var project = new Project("My Project", "Test Project", 1, 2, 1000);

            Assert.Equal(ProjectStatusEnum.Created, ProjectStatusEnum.Created);
            Assert.Null(project.StartedAt);
            
            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);
 
            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, ProjectStatusEnum.InProgress);
            Assert.NotNull(project.StartedAt);
        }
    }
}
