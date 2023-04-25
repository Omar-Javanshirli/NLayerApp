using NLayer.Core.Model;

namespace NLayer.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryWithProductAsync(int categoryId);
    }
}
