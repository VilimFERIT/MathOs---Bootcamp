using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Repository;
using WebApplication.Model;
using WebApplication.Common;
using WebApplication.Service.Common;
using WebApplication.Repository.Common;
using WebApplication.Model.Common;

namespace WebApplication.Service
{
    public class ProductService : IProductService
    {
        public IProductRepository Repository { get; set; }
        public ProductService(IProductRepository repository)
        {
            Repository = repository;
        }
        public async Task<List<IProductModel>> GetProductAsync(Guid id)
        {
            //ProductRepository repository = new ProductRepository();
            return await Repository.GetProductByIdAsync(id);


        }
        public async Task InsertProductAsync(IProductModel product)
        {
            //ProductRepository repository= new ProductRepository();
            await Repository.AddNewProductAsync(product);
        }

        public async Task UpdatePriceMlaAsync(Guid productId, decimal newPrice)
        {
            //ProductRepository productRepository= new ProductRepository();
            await Repository.UpdateProductPriceAsync(productId,newPrice);
        }

        public async Task<List<IProductModel>> GetAllProductsServiceAsync()
        {
            //ProductRepository productRepository = new ProductRepository();
            return await Repository.GetAllProductsAsync(); 
           
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await Repository.DeleteProductAsync(id);
        }
    }
}


