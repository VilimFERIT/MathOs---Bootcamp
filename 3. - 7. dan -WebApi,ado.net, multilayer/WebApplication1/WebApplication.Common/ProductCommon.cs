using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model;

namespace WebApplication.Common
{
   public interface IProduct
    {
       decimal Price { get; set; }

       string Name { get; set; }

        Guid Id { get; set; }

        int Stock { get; set; }

        string CountryOfOrigin { get; set; }

    }
    public class ProductCommon
    {
       
    }
}
