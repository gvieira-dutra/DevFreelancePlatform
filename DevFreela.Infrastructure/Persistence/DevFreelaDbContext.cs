using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("First Project", "my first project", 1, 1, 1000),
                new Project("Second Project", "my second project", 2, 2, 2000),
                new Project("Third Project", "my third project", 3, 3, 3000),
                new Project("Fourth Project", "my fourth project", 4, 4, 4000)
            };

            Users = new List<User>
            { 
                new User("Gleison Dutra", "g@email.com", new DateTime(1990, 1, 31)),
                new User("Adrian Smith", "a@email.com", new DateTime(1991, 1, 30)),
                new User("John Doe", "j@email.com", new DateTime(1992, 1, 29)),
                new User("Mary", "m@email.com", new DateTime(1993, 1, 28))
            };

            Skills = new List<Skill>
            { 
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}