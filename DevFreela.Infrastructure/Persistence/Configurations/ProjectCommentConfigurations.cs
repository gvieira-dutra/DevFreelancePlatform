using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectCommentConfigurations : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder
            .HasKey(p => p.Id);

            builder
                .HasOne(pc => pc.Project)
                .WithMany(pc => pc.Comments)
                .HasForeignKey(pc => pc.IdProject);

            builder
                .HasOne(pc => pc.User)
                .WithMany(pc => pc.Comments)
                .HasForeignKey(pc => pc.IdUser);
        }
    }
}
