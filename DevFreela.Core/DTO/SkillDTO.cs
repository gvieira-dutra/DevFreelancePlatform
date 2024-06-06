namespace DevFreela.Core.DTO
{
    public class SkillDTO
    {
        public SkillDTO(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public string Description { get; set; }
        public int Id { get; set; }
    }
}
