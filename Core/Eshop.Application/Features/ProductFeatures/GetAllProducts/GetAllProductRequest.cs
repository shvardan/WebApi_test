using Eshop.Domain.Common;
using Eshop.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Eshop.Application.Features.ProductFeatures.GetAllProducts
{
    public sealed record GetAllProductRequest : GetManyRequestSpecifications<Product>, IRequest<List<GetAllProductResponse>>;
}