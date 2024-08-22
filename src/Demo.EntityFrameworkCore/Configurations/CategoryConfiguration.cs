using System;
using Demo.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Demo.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ConfigureByConvention();
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name).HasMaxLength(DemoConsts.NameMaxLength).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(DemoConsts.DescriptionMaxLength).IsRequired();

            builder.ToTable("Categories");
        }
    }
}
