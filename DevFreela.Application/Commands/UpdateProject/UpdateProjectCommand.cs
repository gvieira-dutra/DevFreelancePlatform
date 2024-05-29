using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest<Unit>
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal TotalCost { get; set; }
    }
}
