using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Account;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.ObjectMapping;

namespace Demo.Products
{
    public class ProductsAppService : ApplicationService, IProductsAppService
    {
        private readonly IRepository<Product, int> repository;

        public ProductsAppService(IRepository<Product, int> repository)
        {
            this.repository = repository;
        }
        public async Task<ProductDto> CreateProductAsync(CreateUpdateProductDto product)
        {
            var input = ObjectMapper.Map<CreateUpdateProductDto, Product>(product);
            var inputProduct = await repository.InsertAsync(input, autoSave: true);
            return ObjectMapper.Map<Product, ProductDto>(inputProduct);
        }

        public async Task<bool> DeleteProductAsync(int id) 
        {
            var product = await repository.GetAsync(id);
            if (product == null)
            {
                return false;
            }
            await repository.DeleteAsync(id);
            return true;
        }

        public async Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto product)
        {
            if (product.Sorting.IsNullOrWhiteSpace())
            {
                product.Sorting = nameof(Product.Id);
            }
            var products = 
                await repository
                .WithDetailsAsync(x => x.Category)
                .Result
                .AsQueryable()
                .WhereIf(!product.Filter.IsNullOrWhiteSpace(),
                x => x.Name.Contains(product.Filter))
                .Skip(product.SkipCount)
                .Take(product.MaxResultCount)
                .OrderBy(product.Sorting)
                .ToListAsync();


            var totalCount = product.Filter == null ? await repository.CountAsync()
                : await repository.CountAsync(x => x.Name.Contains(product.Filter));

            return new PagedResultDto<ProductDto>( totalCount
                ,ObjectMapper.Map<List<Product>, List<ProductDto>>(products));
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var product = await repository.WithDetailsAsync(x => x.Category)
                .Result.FirstOrDefaultAsync(x => x.Id == id);
            
            if(product == null)
            {
                throw new ProductNotFoundException(id);
            }
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProductAsync(CreateUpdateProductDto product)
        {
            var existedProduct = await repository.GetAsync(product.Id);
            if (existedProduct == null)
            {
                throw new ProductNotFoundException(product.Id);
            }
            var input = ObjectMapper.Map<CreateUpdateProductDto, Product>(product, existedProduct);
            var updated = await repository.InsertAsync(input, autoSave: true);
            return ObjectMapper.Map<Product, ProductDto>(updated);
        }
    }
}
