using Dapper;
using DevFreela.Core.DTO;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.Data.SqlClient;

using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Queries.GetAllSkills
{
    internal class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillDTO>>
    {
        private readonly ISkillRepository _skillRepository;

        public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetAll();
        }
    }
}
