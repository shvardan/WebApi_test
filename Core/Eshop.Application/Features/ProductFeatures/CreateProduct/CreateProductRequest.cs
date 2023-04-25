using MediatR;

namespace Eshop.Application.Features.ProductFeatures.CreateProduct
{
    public sealed record CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Name { get; init; }
        public int Price { get; init; }
        public string Barcode { get; init; }
        public int PLU { get; init; }
    }
}