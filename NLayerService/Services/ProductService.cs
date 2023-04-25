using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Model;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerService.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepo, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductWithCatagoryDto>>> GetProductWithCategory()
        {
            var products = await _productRepo.GetProductWithCategory();
            var productsDto = _mapper.Map<List<ProductWithCatagoryDto>>(products);
            return CustomResponseDto<List<ProductWithCatagoryDto>>.Success(200, productsDto);
        }
    }
}
