using Microsoft.AspNetCore.Mvc;

namespace ProductApiBack.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProducts();

        public Task<Product> GetSingleProduct(int id);

        public Task<Product> CreateProduct(Product product);

        public Task<Product> EditProduct(Product product);

        public Task<Product> DeleteProduct(int id);
    }
}
