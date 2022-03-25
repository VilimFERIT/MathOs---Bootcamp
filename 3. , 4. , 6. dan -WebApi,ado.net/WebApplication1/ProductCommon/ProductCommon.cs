using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCommon
{
    public class ProductCommon
    {
        public class Product
        {
            Product product = new Product();
            public decimal Price { get; set; }

            public string Name { get; set; }

            public int Stock { get; set; }

            public string CountryOfOrigin { get; set; }

        }
    }
}
