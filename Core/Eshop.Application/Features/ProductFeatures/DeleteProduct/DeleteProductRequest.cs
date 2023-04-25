using MediatR;

namespace Eshop.Application.Features.ProductFeatures.DeleteProduct
{
    public sealed record DeleteProductRequest(long ID) : IRequest<DeleteProductResponse>;
}