namespace DevFreela.Application.Queries.GetProjectById
{
    public class ProjectDetailViewModel
    {
        public ProjectDetailViewModel(int id, string title, string description, DateTime? startedAt, DateTime? finishedAt, decimal totalCost, string clientFullName, string freelanceFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            TotalCost = totalCost;
            ClientFullName = clientFullName;
            FreelanceFullName = freelanceFullName;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public decimal TotalCost { get; private set; }

        public string ClientFullName { get; private set; }
        public string FreelanceFullName { get; private set; }
    }
}