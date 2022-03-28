using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Repository;
using WebApplication.Model;

namespace WebApplication.Service
{
    public class ProductService
    {
    public async Task<List<ProductModel>> GetProductAsync(Guid id)
        {
            ProductRepository repository = new ProductRepository();
            return await repository.GetProductByIdAsync(id);


        }
    public async Task InsertProductAsync(ProductModel product)
        {
            ProductRepository repository= new ProductRepository();
            await repository.AddNewProductAsync(product);
        }

    public async Task UpdatePriceMlaAsync(Guid productId, decimal newPrice)
        {
            ProductRepository productRepository= new ProductRepository();
            await productRepository.UpdateProductPriceAsync(productId,newPrice);
        }
    }
}


