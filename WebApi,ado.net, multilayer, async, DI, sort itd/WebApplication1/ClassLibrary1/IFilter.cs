using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IFilter
    {
        decimal? Price { get; set; }

        string Name { get; set; }

        int? Stock { get; set; }

        string CountryOfOrigin { get; set; }
    }
}
