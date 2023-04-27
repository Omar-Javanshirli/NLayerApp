using NLayer.Core.DTOs;
using NLayer.Core.Model;

namespace NLayer.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<List<ProductWithCatagoryDto>> GetProductWithCategory();
    }
}
