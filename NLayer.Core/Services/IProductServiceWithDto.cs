using NLayer.Core.DTOs;
using NLayer.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IProductServiceWithDto : IServiceWithDto<Product, ProductDTO>
    {
        Task<CustomResponseDto<List<ProductWithCatagoryDto>>> GetProductWithCategory();
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(ProductUpdateDTO dto);
        Task<CustomResponseDto<ProductDTO>> AddAsync(ProductCreateDto dto);
    }
}
