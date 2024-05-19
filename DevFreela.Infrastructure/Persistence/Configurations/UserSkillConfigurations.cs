// Ignore Spelling: Freela

using Microsoft.EntityFrameworkCore;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserSkillConfigurations : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder
            .HasKey(us => us.Id);
        }
    }
}
