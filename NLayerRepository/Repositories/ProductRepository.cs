using Microsoft.EntityFrameworkCore;
using NLayer.Core.Model;
using NLayer.Core.Repositories;

namespace NLayerRepository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductWithCategory()
        {
            //Eager loading
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
