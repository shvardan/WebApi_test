using Eshop.Application.Common.Helpers;
using Eshop.Application.Features.ProductFeatures.GetAllProducts;
using Eshop.Domain.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Application.Features.Common
{
    public class GetManyValidator<T> : AbstractValidator<GetManyRequestSpecifications<T>>
    {
        private Type _filterProperyType = null;
        public GetManyValidator()
        {
            RuleFor(x => x.SortByProperty)
                .Must((request, x) => string.IsNullOrEmpty(x) || request.EntityType.IsValidSortProperty(x));

            RuleFor(x => x.FilterByProperty)
                .Must((request, x) => string.IsNullOrEmpty(x) || request.EntityType.IsValidFilterProperty(x, out _filterProperyType));

            RuleFor(x => x.FilterCriteria).NotNull().IsInEnum().When(x => !string.IsNullOrEmpty(x.FilterByProperty));

            RuleFor(x => x.FilterValue1).Must((requst, x) =>
            {
                if (x != null && _filterProperyType != null && EntityTypeHelper.IsValidFilterValue(_filterProperyType, x, out string formattedValue))
                {
                    requst.FilterValue1 = formattedValue;
                    return true;
                }
                return false;
                
            }).When(x => !string.IsNullOrEmpty(x.FilterByProperty));

            RuleFor(x => x.FilterValue2).Must((requst, x) =>
            {
                if (x != null && _filterProperyType != null && EntityTypeHelper.IsValidFilterValue(_filterProperyType, x, out string formattedValue))
                {
                    requst.FilterValue1 = formattedValue;
                    return true;
                }
                return false;

            }).When(x => x.FilterCriteria != null && x.FilterCriteria is FilterCriteria.Between);
        }
    }
}
