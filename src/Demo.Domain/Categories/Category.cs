using Volo.Abp.Domain.Entities.Auditing;

namespace Demo.Categories
{
    public class Category : FullAuditedEntity<int>
    {
        public Category(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
