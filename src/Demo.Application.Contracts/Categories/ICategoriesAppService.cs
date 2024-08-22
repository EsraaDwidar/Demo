﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Demo.Categories
{
    public  interface ICategoriesAppService : ICrudAppService<CategoryDto, int, PagedAndSortedResultRequestDto, UpdateCategoryDto>
    {
    }
}
