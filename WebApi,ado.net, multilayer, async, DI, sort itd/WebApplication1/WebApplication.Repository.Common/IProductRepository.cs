using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model;
using WebApplication.Model.Common;

namespace WebApplication.Repository.Common
{
    public interface IProductRepository
    {
       
            Task<List<IProductModel>> GetProductByIdAsync(Guid id);
            Task AddNewProductAsync(IProductModel newProduct);

            Task UpdateProductPriceAsync(Guid productId, decimal newPrice);

            Task<List<IProductModel>> GetAllProductsAsync();

            Task<List<IProductModel>> GetProductModelsAsyncSortPageFilter(ISort sort, IPage page, IFilter filter);

            Task DeleteProductAsync(Guid id);
    }
}
