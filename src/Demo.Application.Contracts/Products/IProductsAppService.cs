using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Demo.Products
{
    public interface IProductsAppService
    {
        Task<ProductDto> CreateProductAsync(CreateUpdateProductDto product);
        Task<ProductDto> UpdateProductAsync(CreateUpdateProductDto product);
        Task<ProductDto> GetProductAsync(int id);
        Task<bool> DeleteProductAsync(int id);
        Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto product);
    }
}
