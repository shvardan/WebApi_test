using FluentValidation;

namespace Eshop.Application.Features.ProductFeatures.GetProduct
{
    public sealed class GetProductValidator : AbstractValidator<GetProductRequest>
    {
        public GetProductValidator()
        {
            RuleFor(x => x.ID).GreaterThan(0);
        }
    }
}