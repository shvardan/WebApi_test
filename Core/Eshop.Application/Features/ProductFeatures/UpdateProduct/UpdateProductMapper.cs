using AutoMapper;
using Eshop.Domain.Entities;

namespace Eshop.Application.Features.ProductFeatures.UpdateProduct
{
    public sealed class UpdateProductMapper : Profile
    {
        public UpdateProductMapper()
        {
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, UpdateProductResponse>();
        }
    }
}