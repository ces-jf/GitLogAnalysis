using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Infra.Data.Mappings
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("TB_PROJECT");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_PROJECT");

            builder.Property(x => x.Active)
                .HasDefaultValue(true)
                .HasColumnName("FL_ACTIVE");

            builder.Property(x => x.ProjectName)
                .HasMaxLength(50)
                .HasColumnName("DS_PROJECT_NAME");

            builder.Property(x => x.Directory)
                .IsRequired()
                .HasColumnName("DS_DIRECTORY");
        }
    }
}
