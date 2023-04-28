using NLayer.Core.DTOs;

namespace NLayerWeb.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductWithCatagoryDto>> GetProductsWithCategoryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCatagoryDto>>>("products/GetProductWithCategory");
            return response.Data;
        }

        public async Task<ProductDTO> SaveAsync(ProductDTO newProduct)
        {
            var response = await _httpClient.PostAsJsonAsync("products", newProduct);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDTO>>();
            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(ProductDTO newProduct)
        {
            var response = await _httpClient.PutAsJsonAsync("products", newProduct);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDTO>>($"products/{id}");
            return response.Data;
        }
    }
}
