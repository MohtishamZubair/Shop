using System.Collections.Generic;

namespace Shop.Models
{
    public class ProductViewAll
    {
        public IEnumerable<ProductView> ProductViews { get; set; }
        public int TotalCount { get; set; }
    }
}