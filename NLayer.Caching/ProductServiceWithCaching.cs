using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayer.Core.DTOs;
using NLayer.Core.Model;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayerService.Exceptions;
using System.Linq.Expressions;

namespace NLayer.Caching
{
    public class ProductServiceWithCaching : IProductService
    {
        private const string CacheProductKey = "productCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductServiceWithCaching(IMapper mapper, IMemoryCache cache, IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _cache = cache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            //Result yazdigimiz zaman asixron methodu sixron edir bizde constructurda asixron istifade ede bilmediyimize gore 500 statux code error alirdix
            if (!_cache.TryGetValue(CacheProductKey, out _))
                cache.Set(CacheProductKey, _repository.GetProductWithCategory().Result);
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_cache.Get<IEnumerable<Product>>(CacheProductKey));
        }

        public Task<Product> GetByIdAsync(int id)
        {
            var product = _cache.Get<List<Product>>(CacheProductKey)
                 .FirstOrDefault(x => x.Id == id);

            if (product == null)
                throw new NotFoundException($"{typeof(Product).Name} not found");

            return Task.FromResult(product);
        }

        public Task<List<ProductWithCatagoryDto>> GetProductWithCategory()
        {
            var products = _cache.Get<IEnumerable<Product>>(CacheProductKey);
            var productsWithCategoryDto = _mapper.Map<List<ProductWithCatagoryDto>>(products);
            return Task.FromResult(productsWithCategoryDto);
        }

        public async Task RemoveAsync(Product entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Product> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            //Compile method=>Function cevirir;
            return _cache.Get<List<Product>>(CacheProductKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllProductsAsync()
        {
            await _cache.Set(CacheProductKey, _repository.GetAll().ToListAsync());
        }
    }
}
