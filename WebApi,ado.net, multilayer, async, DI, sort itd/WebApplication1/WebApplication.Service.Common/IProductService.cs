using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model;
using WebApplication.Model.Common;

namespace WebApplication.Service.Common
{
    public interface IProductService
    {
        Task<List<IProductModel>> GetProductAsync(Guid id);
        Task InsertProductAsync(IProductModel product);
        Task UpdatePriceMlaAsync(Guid productId, decimal newPrice);

        Task<List<IProductModel>> GetAllProductsServiceAsync();

        Task DeleteProductAsync(Guid productId);


    }
}
