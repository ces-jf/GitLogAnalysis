using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Infra.Data.Mappings
{
    public class ReleaseDataMap : IEntityTypeConfiguration<ReleaseData>
    {
        public void Configure(EntityTypeBuilder<ReleaseData> builder)
        {
            builder.ToTable("TB_RELEASE_DATA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_RELEASE");

            builder.Property(x => x.Active)
                .HasDefaultValue(true)
                .HasColumnName("FL_ACTIVE");

            builder.Property(x => x.ReleaseName)
                .HasMaxLength(50)
                .HasColumnName("DS_RELEASE_NAME");

            builder.Property(x => x.Authors)
                .IsRequired()
                .HasColumnName("NR_AUTHORS");

            builder.Property(x => x.Commits)
                .IsRequired()
                .HasColumnName("NR_COMMITS");

            builder.Property(x => x.InitialDate)
                .IsRequired(true)
                .HasColumnName("DT_INITIAL")
                .HasColumnType("datetime");

            builder.Property(x => x.FinalDate)
                .IsRequired(true)
                .HasColumnName("DT_FINAL")
                .HasColumnType("datetime");

            builder.Property(x => x.AddedLines)
                .IsRequired(false)
                .HasColumnName("NR_ADDED_LINES");

            builder.Property(x => x.RemovedLines)
                .IsRequired(false)
                .HasColumnName("NR_REMOVED_LINES");

            builder.Property(x => x.IdProject)
                .IsRequired()
                .HasColumnName("ID_PROJECT");

            builder.HasOne(x => x.Project)
                .WithMany(r => r.ReleaseDatas)
                .HasForeignKey(x => x.IdProject)
                .IsRequired();
        }
    }
}
