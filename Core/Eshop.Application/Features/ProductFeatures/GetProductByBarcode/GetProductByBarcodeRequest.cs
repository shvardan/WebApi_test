using MediatR;

namespace Eshop.Application.Features.ProductFeatures.GetProductByBarcode
{
    public sealed record GetProductByBarcodeRequest(string Barcode) : IRequest<GetProductByBarcodeResponse>;
}