using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Producto");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id");
            
            builder.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.Descripcion)
                            .HasColumnName("Descripcion")
                            .IsRequired()
                            .HasMaxLength(1000)
                            .IsUnicode(false);

            builder.Property(e => e.Categoria)
                .HasColumnName("Categoria")
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);
        }
    }
}
