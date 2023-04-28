using AutoMapper;
using Microsoft.AspNetCore.Http;
using NLayer.Core.DTOs;
using NLayer.Core.Model;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayerService.Services
{
    public class ProductServiceWithDto : ServiceWithDto<Product, ProductDTO>, IProductServiceWithDto
    {
        private readonly IProductService _productService;

        public ProductServiceWithDto(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductService productService) :
            base(repository, unitOfWork, mapper)
        {
            _productService = productService;
        }

        public async Task<CustomResponseDto<ProductDTO>> AddAsync(ProductCreateDto dto)
        {
            var newEntity = _mapper.Map<Product>(dto);
            await _productService.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = _mapper.Map<ProductDTO>(newEntity);
            return CustomResponseDto<ProductDTO>.Success(StatusCodes.Status200OK, newDto);
        }

        public Task<CustomResponseDto<List<ProductWithCatagoryDto>>> GetProductWithCategory()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(ProductUpdateDTO dto)
        {
            var entity = _mapper.Map<Product>(dto);
            await _productService.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
