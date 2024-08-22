using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Demo.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ConfigureByConvention();

            builder.Property(x => x.Name).HasMaxLength(DemoConsts.NameMaxLength).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(DemoConsts.DescriptionMaxLength).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasOne(x => x.Category).WithMany()
                .HasForeignKey(x => x.CategoryId).IsRequired();

            builder.ToTable("Products");
        }
    }
}
