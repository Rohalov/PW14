using System.Net.Http.Json;
using task.client.Models;

namespace task.client.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>("https://localhost:7273/api/Products");
            return products;
        }

        public async Task<Product> AddProductAsync(Product newProduct)
        {
            var result = await _httpClient.PostAsJsonAsync("https://localhost:7273/api/Products", newProduct);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadFromJsonAsync<Product>();
        }

        public async Task<Product> UpdateProductAsync(int id, Product updatedProduct)
        {
            var result = await _httpClient.PutAsJsonAsync($"https://localhost:7273/api/Products/{id}", updatedProduct);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadFromJsonAsync<Product>();
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var result = await _httpClient.DeleteAsync($"https://localhost:7273/api/Products/{id}");    
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadFromJsonAsync<Product>();
        }
    }
}
