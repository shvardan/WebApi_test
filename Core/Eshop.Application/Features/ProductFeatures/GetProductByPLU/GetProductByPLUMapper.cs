using AutoMapper;
using Eshop.Domain.Entities;

namespace Eshop.Application.Features.ProductFeatures.GetProductByPLU
{
    public sealed class GetProductByPLUMapper : Profile
    {
        public GetProductByPLUMapper()
        {
            CreateMap<GetProductByPLURequest, Product>();
            CreateMap<Product, GetProductByPLUResponse>();
        }
    }
}