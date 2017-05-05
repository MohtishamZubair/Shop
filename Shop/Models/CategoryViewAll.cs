using System.Collections.Generic;

namespace Shop.Models
{
    public class CategoryViewAll
    {
        public List<CategoryView> CategoryViews { get; set; }
        public int TotalCount { get; set; }
        public int? HighLightId { get; set; }
    }
}