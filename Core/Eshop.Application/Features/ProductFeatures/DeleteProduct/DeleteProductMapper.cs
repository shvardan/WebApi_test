using AutoMapper;
using Eshop.Domain.Entities;

namespace Eshop.Application.Features.ProductFeatures.DeleteProduct
{
    public sealed class DeleteProductMapper : Profile
    {
        public DeleteProductMapper()
        {
            CreateMap<DeleteProductRequest, Product>();
        }
    }
}