using FluentValidation;

namespace Eshop.Application.Features.ProductFeatures.GetProductByBarcode
{
    public sealed class GetProductByBarcodeValidator : AbstractValidator<GetProductByBarcodeRequest>
    {
        public GetProductByBarcodeValidator()
        {
            RuleFor(x => x.Barcode).NotEmpty().Length(13);
        }
    }
}