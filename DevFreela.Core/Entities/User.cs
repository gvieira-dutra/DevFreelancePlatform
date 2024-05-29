namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = true;

            CreatedAt = DateTime.Now;
            Skills = new List<UserSkill>();
            OwnedProjects = new List<Project>();
            FreelaceProjects = new List<Project>();
        }

        public bool Active { get; set; }
        public DateTime BirthDate { get; private set; }
        public List<ProjectComment> Comments { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Email { get; private set; }
        public List<Project> FreelaceProjects { get; set; }
        public string FullName { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<UserSkill> Skills { get; private set; }
    }
}
