using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Application.Features.ProductFeatures.ProductCommon
{
    public record ProductResponse
    {
        public long ID { get; init; }
        public string Name { get; init; }
        public int Price { get; init; }
        public string Barcode { get; init; }
        public int PLU { get; init; }
        public string ImageUrl { get; init; }
        public DateTimeOffset DateCreated { get; init; }
        public DateTimeOffset? DateModified { get; init; }
    }
}
