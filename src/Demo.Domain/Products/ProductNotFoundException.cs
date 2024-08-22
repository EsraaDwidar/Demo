using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Demo.Products
{
    public class ProductNotFoundException : BusinessException
    {
        public ProductNotFoundException(int id) : base(DemoDomainErrorCodes.NotFound)
        {
            WithData("id", id);
        }
    }
}
