using Eshop.Domain.Common;
using Eshop.Domain.CustomAttributes;

namespace Eshop.Domain.Entities
{
    public class Product : BaseEntity
    {
        [SortProperty]
        public string Name { get; set; }

        [SortProperty, FilterProperty]
        public decimal Price { get; set; }

        public string Barcode { get; set; }

        [SortProperty, FilterProperty]
        public int PLU { get; set; }

        public string ImageUrl { get; set; }
    }
}
