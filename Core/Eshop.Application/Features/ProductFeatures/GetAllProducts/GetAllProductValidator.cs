using Eshop.Application.Features.Common;
using Eshop.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Application.Features.ProductFeatures.GetAllProducts
{
    public sealed class GetAllProductValidator : AbstractValidator<GetAllProductRequest>
    {
        public GetAllProductValidator()
        {
            Include(new GetManyValidator<Product>());
        }
    }
}
