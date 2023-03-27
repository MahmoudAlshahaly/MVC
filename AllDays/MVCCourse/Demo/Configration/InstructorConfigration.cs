using Day2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.Configration
{
    public class InstructorConfigration:IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.id);

            builder.Property(i => i.name)
                   .IsUnicode(false) //varchar not nvarchar
                   .IsRequired() //not null
                   .HasMaxLength(50);

            builder.Property(i => i.salary)
                   .HasDefaultValue(5000);
        }
    }
}
