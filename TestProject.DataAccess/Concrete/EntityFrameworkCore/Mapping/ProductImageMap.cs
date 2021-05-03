using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Entity.Concrete;

namespace TestProject.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ProductImageMap : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable(@"ProductImages", @"dbo");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.AddedBy).HasColumnName("AddedBy");
            builder.Property(d => d.AddedDate).HasColumnName("AddedDate");
            builder.Property(d => d.FileName).HasColumnName("FileName");
            builder.Property(d => d.FilePath).HasColumnName("filePath");
            builder.Property(d => d.ProductId).HasColumnName("ProductId");
        }
    }
}
