using FormulaOne.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Presistence.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(t => t.Id)
                .IsRequired();

            builder.Property(t => t.FullTeamName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Base)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.TeamChief)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.TechnicalChief)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Chassis)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.PowerUnit)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.HighestRaceFinish)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
