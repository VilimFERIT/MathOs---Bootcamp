using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Common;

namespace WebApplication1.Controllers
{
    public class Product: IProduct
    {
        public decimal Price { get; set; }

        public string Name { get; set; }

        public Guid Id { get; set; }

        public int Stock { get; set; }

        public string CountryOfOrigin { get; set; }

    }
}