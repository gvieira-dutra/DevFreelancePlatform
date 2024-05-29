namespace DevFreela.Application.Queries.GetAllSkills
{
    public class SkillViewModel
    {
        public SkillViewModel(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public string Description { get; set; }
        public int Id { get; set; }
    }
}
