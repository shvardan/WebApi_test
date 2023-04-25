using MediatR;

namespace Eshop.Application.Features.ProductFeatures.GetProduct
{
    public sealed record GetProductRequest(long ID) : IRequest<GetProductResponse>;
}