using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateCommentCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            if (request.Content == null || request.Content == "")
            {
                throw new ArgumentNullException(nameof(request.Content));
            }

            var myProj = await _projectRepository.GetByIdAsync(request.IdProject);

            if (myProj == null)
                throw new ArgumentException("No project exists with given ID");

            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _projectRepository.AddCommentAsync(comment);

            return Unit.Value;
        }
    }
}
