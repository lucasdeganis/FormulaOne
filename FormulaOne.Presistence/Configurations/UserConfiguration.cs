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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.Id)
                .IsRequired();

            builder.Property(t => t.UserName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Password)
                .HasMaxLength(18)
                .IsRequired();
        }
    }
}
