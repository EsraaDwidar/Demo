using Demo.Categories;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demo.Products
{
    public class Product : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
