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
    public List<ProductModel> GetProduct(Guid id)
        {
            ProductRepository repository = new ProductRepository();
            return repository.GetProductById(id);


        }
    public void InsertProduct(ProductModel product)
        {
            ProductRepository repository= new ProductRepository();
            repository.AddNewProduct(product);
        }

    public void UpdatePriceMla(Guid productId, decimal newPrice)
        {
            ProductRepository productRepository= new ProductRepository();
            productRepository.UpdateProductPrice(productId,newPrice);
        }
    }
}


