using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model.Common;

namespace WebApplication.Model
{
    public class ProductModel : IProductModel
    {
            public decimal Price { get; set; }

            public string Name { get; set; }

            public Guid Id { get; set; }

            public int Stock { get; set; }

            public string CountryOfOrigin { get; set; }
    }
}
