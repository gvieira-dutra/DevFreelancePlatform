using MediatR;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<ProjectDetailViewModel>
    {

        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
