using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Common
{
    public class ProductCommon
    {
        public decimal Price { get; set; }

        public string Name { get; set; }

        public Guid Id { get; set; }

        public int Stock { get; set; }

        public string CountryOfOrigin { get; set; }
    }
}
