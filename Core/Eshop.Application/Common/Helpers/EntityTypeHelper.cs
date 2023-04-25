using Eshop.Domain.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Application.Common.Helpers
{
    public static class EntityTypeHelper
    {
        public static bool IsValidSortProperty(this Type type, string sortPropertyName)
        {
            var propInfos = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            if (propInfos != null && propInfos.Any())
            {
                return propInfos
                    .Where(x => x.CustomAttributes != null && x.CustomAttributes.Any(a => a.AttributeType == typeof(SortPropertyAttribute)))
                    .Any(x => x.Name.ToLower() == sortPropertyName.ToLower());
            }

            return false;
        }

        public static bool IsValidFilterProperty(this Type type, string filterPropertyName, out Type filterPropertyType)
        {
            var propInfos = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            if (propInfos != null && propInfos.Any())
            {
                var filterProperty = propInfos
                    .Where(x => x.CustomAttributes != null && x.CustomAttributes.Any(a => a.AttributeType == typeof(FilterPropertyAttribute)))
                    .FirstOrDefault(x => x.Name.ToLower() == filterPropertyName.ToLower());
                if (filterProperty != null)
                {
                    filterPropertyType = filterProperty.PropertyType;
                    return true;
                }
            }

            filterPropertyType = default;
            return false;
        }

        public static bool IsValidFilterValue(Type filterType, object filterValue, out string formattedValue)
        {
            string val = filterValue.ToString();
            if (filterType == typeof(DateTimeOffset) || filterType == typeof(DateTimeOffset?))
            {
                if (DateTimeOffset.TryParse(val, out DateTimeOffset dateFilter))
                {
                    formattedValue = string.Format("'{0}'", val);
                    return true;
                }
            }
            else if (filterType == typeof(int) || filterType == typeof(decimal) || filterType == typeof(long))
            {
                if (long.TryParse(val, out _))
                {
                    formattedValue = val;
                    return true;
                }
            }

            formattedValue = string.Empty;
            return false;
        }
    }
}
