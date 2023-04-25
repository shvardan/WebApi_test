using AutoMapper;
using Eshop.Domain.Entities;

namespace Eshop.Application.Features.ProductFeatures.GetProduct
{
    public sealed class GetProductMapper : Profile
    {
        public GetProductMapper()
        {
            CreateMap<GetProductRequest, Product>();
            CreateMap<Product, GetProductResponse>();
        }
    }
}