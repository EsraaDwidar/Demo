using Volo.Abp.Application.Dtos;

namespace Demo.Categories
{
    public class CategoryDto : FullAuditedEntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
