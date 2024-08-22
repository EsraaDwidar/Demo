using AutoMapper;
using Demo.Categories;
using Demo.Products;

namespace Demo;

public class DemoApplicationAutoMapperProfile : Profile
{
    public DemoApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Category, CategoryDto>();
        CreateMap<UpdateCategoryDto, Category>();

        CreateMap<Product, ProductDto>();
        CreateMap<CreateUpdateProductDto, Product>();
    }
}
