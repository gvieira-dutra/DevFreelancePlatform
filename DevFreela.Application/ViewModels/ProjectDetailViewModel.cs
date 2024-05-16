using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailViewModel
    {
        public ProjectDetailViewModel(int id, string title, string description, DateTime? startedAt, DateTime? finishedAt, decimal totalCost)
        {
            Id = id;
            Title = title;
            Description = description;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            TotalCost = totalCost;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt{ get; private set; }
        public decimal TotalCost { get; private set; }

    }
}
