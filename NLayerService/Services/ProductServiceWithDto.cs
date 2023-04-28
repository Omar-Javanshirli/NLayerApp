using NLayer.Core.DTOs;
using NLayer.Core.Model;
using NLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerService.Services
{
    internal class ProductServiceWithDto : ServiceWithDto<Product, ProductDTO>, IProductServiceWithDto
    {
        public Task<CustomResponseDto<List<ProductWithCatagoryDto>>> GetProductWithCategory()
        {
            throw new NotImplementedException();
        }
    }
}
