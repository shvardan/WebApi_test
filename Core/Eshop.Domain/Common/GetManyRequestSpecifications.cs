using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Domain.Common
{
    public record GetManyRequestSpecifications<T>
    {
        public string SortByProperty { get; init; }
        public bool? SortByDescending { get; init; }
        public string FilterByProperty { get; init; }
        public FilterCriteria? FilterCriteria { get; init; }
        public object FilterValue1 { get; set; }
        public object FilterValue2 { get; set; }
        public bool? FilterExclude { get; init; }
        public int? Take { get; init; }
        public int? Skip { get; init; }
        public Type EntityType => typeof(T);
    }
}
