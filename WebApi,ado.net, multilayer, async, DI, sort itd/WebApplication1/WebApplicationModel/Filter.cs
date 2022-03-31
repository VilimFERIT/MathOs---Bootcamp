using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model.Common;

namespace WebApplicationModel
{
    public class Filter : IFilter
    {
        public decimal? Price { get; set; }

        public string Name { get; set; }

        public int? Stock { get; set; }

        public string CountryOfOrigin { get; set; }
    }
}
