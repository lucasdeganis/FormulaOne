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
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.Property(t => t.Id)
                .HasConversion<Guid>()
                .IsRequired();

            builder.Property(t => t.Season)
                .IsRequired();

            builder.Property(t => t.NumberCar)
                .IsRequired();

            //builder.Property(t => t.Person)
            //    .HasColumnName("PersonId")
            //    //.ValueGeneratedOnAddOrUpdate()
            //    .IsRequired();

            //builder.Property(t => t.Team)
            //    .ValueGeneratedOnAddOrUpdate()
            //    .IsRequired();
        }
    }
}
