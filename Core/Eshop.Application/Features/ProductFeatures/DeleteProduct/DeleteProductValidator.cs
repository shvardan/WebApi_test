using FluentValidation;

namespace Eshop.Application.Features.ProductFeatures.DeleteProduct
{
    public sealed class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.ID).GreaterThan(0);
        }
    }
}