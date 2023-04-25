using MediatR;

namespace Eshop.Application.Features.ProductFeatures.UpdateProduct
{
    public sealed record UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public long ID { get; init; }
        public string Name { get; init; }
        public int Price { get; init; }
        public string Barcode { get; init; }
        public int PLU { get; init; }
    }
}