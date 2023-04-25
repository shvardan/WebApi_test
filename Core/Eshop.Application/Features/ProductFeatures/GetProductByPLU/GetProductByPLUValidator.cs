using FluentValidation;

namespace Eshop.Application.Features.ProductFeatures.GetProductByPLU
{
    public sealed class GetProductByPLUValidator : AbstractValidator<GetProductByPLURequest>
    {
        public GetProductByPLUValidator()
        {
            RuleFor(x => x.PLU).GreaterThanOrEqualTo(1).LessThanOrEqualTo(99999);
        }
    }
}