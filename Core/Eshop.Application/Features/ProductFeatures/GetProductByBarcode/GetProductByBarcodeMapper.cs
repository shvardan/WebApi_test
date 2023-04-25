using AutoMapper;
using Eshop.Domain.Entities;

namespace Eshop.Application.Features.ProductFeatures.GetProductByBarcode
{
    public sealed class GetProductByBarcodeMapper : Profile
    {
        public GetProductByBarcodeMapper()
        {
            CreateMap<GetProductByBarcodeRequest, Product>();
            CreateMap<Product, GetProductByBarcodeResponse>();
        }
    }
}