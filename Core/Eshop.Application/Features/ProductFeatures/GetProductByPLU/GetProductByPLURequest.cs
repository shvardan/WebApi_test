using MediatR;

namespace Eshop.Application.Features.ProductFeatures.GetProductByPLU
{
    public sealed record GetProductByPLURequest(int PLU) : IRequest<GetProductByPLUResponse>;
}