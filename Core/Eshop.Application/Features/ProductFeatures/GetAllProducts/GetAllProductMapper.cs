using AutoMapper;
using Eshop.Domain.Entities;

namespace Eshop.Application.Features.ProductFeatures.GetAllProducts
{
    public sealed class GetAllProductMapper : Profile
    {
        public GetAllProductMapper()
        {
            CreateMap<Product, GetAllProductResponse>();
        }
    }
}