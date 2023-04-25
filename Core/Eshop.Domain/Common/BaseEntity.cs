using Eshop.Domain.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Domain.Common
{
    public class BaseEntity
    {
        [SortProperty, FilterProperty]
        public long ID { get; set; }

        [SortProperty, FilterProperty]
        public DateTimeOffset DateCreated { get; set; }

        [SortProperty, FilterProperty]
        public DateTimeOffset? DateModified { get; set; }
    }
}
