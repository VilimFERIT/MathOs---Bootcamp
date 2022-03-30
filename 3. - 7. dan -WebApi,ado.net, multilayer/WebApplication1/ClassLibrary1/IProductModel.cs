using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Model.Common
{
    public interface IProductModel
    {
        decimal Price { get; set; }

        string Name { get; set; }

        Guid Id { get; set; }

        int Stock { get; set; }

        string CountryOfOrigin { get; set; }
    }
}
