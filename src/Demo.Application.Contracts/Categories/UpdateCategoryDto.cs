using Volo.Abp.Application.Dtos;

namespace Demo.Categories
{
    public class UpdateCategoryDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
