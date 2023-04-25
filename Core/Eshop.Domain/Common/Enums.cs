using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Domain.Common
{
    public enum FilterCriteria
    {
        GreaterThen = 0,
        GreaterThenOrEqual = 1,
        LessThen = 2,
        LessThenOrEqual = 3,
        Between = 4,
        Equal = 5,
        NotEqual = 6
    }
}
