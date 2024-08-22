using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Categories;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Demo.Data.Categories
{
    public class CategoriesDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category, int> categoriesRepo;

        public CategoriesDataSeeder(IRepository<Category, int> categoriesRepo) 
        {
            this.categoriesRepo = categoriesRepo;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (!await categoriesRepo.AnyAsync())
            {
                var categories = new List<Category>
                {
                    new Category(
                        id: 1,
                        name: "foods",
                        description: "all foods is good"
                        ),
                    new Category(
                        id: 2,
                        name: "drinks",
                        description: "all drinks is good"
                        ),
                };
                await categoriesRepo.InsertManyAsync(categories);
            }
        }
    }
}
