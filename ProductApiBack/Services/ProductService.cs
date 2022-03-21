using Microsoft.AspNetCore.Mvc;

namespace ProductApiBack.Services
{
    public class ProductService : IProductService
    {

        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product> GetSingleProduct(int id)
        {
            return await _dataContext.Products.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _dataContext.Products.Add(product);
            await _dataContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> EditProduct(Product product)
        {
            var productInDb = await _dataContext.Products.SingleOrDefaultAsync(x => x.Id == product.Id);
            
            productInDb.Name = product.Name;
            productInDb.Description = product.Description;
            productInDb.SourceSku = product.SourceSku;
            productInDb.DestinationSku = product.DestinationSku;
            productInDb.Stock = product.Stock;
            productInDb.Price = product.Price;

            await _dataContext.SaveChangesAsync();

            return product;

        }

        public async Task<bool> DeleteProduct(int id)
        {
            var productInDb = await _dataContext.Products.SingleOrDefaultAsync(x => x.Id == id);
            _dataContext.Products.Remove(productInDb);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
