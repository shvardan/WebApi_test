using AutoMapper;
using Eshop.Domain.Entities;

namespace Eshop.Application.Features.ProductFeatures.CreateProduct
{
    public sealed class CreateProductMapper : Profile
    {
        public CreateProductMapper()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, CreateProductResponse>();
        }
    }
}