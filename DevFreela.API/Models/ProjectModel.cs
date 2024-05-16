namespace DevFreela.Models
{
    public class CreateProjectModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
    }

    public class UpdateProjectModel
    {
        public string Description { get; set; }
    }
}