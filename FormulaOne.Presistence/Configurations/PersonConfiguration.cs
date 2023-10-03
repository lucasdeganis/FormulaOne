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
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(t => t.Id)
                .IsRequired();

            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.CountryCode)
                .HasMaxLength(2);

            builder.Property(t => t.PlaceOfBirth)
                .HasMaxLength(100);
        }
    }
}
