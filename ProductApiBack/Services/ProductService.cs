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
            var productInDb = await _dataContext.Products.SingleOrDefaultAsync(x => x.Id == id);

            if (productInDb == null)
                throw new Exception("Product not found");

            return productInDb;
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

            if (productInDb == null)
                throw new Exception("Product not found");

            try
            {
                productInDb.Name = product.Name;
                productInDb.Description = product.Description;
                productInDb.SourceSku = product.SourceSku;
                productInDb.DestinationSku = product.DestinationSku;
                productInDb.Stock = product.Stock;
                productInDb.Price = product.Price;

                throw new Exception("a");

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error while saving product changes");
            }

            return product;

        }

        public async Task<Product> DeleteProduct(int id)
        {
            var productInDb = await _dataContext.Products.SingleOrDefaultAsync(x => x.Id == id);
            _dataContext.Products.Remove(productInDb);
            await _dataContext.SaveChangesAsync();
            return productInDb;
        }
    }
}
