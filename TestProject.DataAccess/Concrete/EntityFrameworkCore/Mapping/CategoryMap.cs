using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Entity.Concrete;

namespace TestProject.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(@"Categories", @"dbo");
            builder.HasKey(d => d.Id);

            builder.Property(p => p.AddedBy).HasColumnName("AddedBy");
            builder.Property(p => p.AddedDate).HasColumnName("AddedDate");
            builder.Property(p => p.IsActive).HasColumnName("IsActive");
            builder.Property(p => p.Name).HasColumnName("Name");
        }
    }
}
