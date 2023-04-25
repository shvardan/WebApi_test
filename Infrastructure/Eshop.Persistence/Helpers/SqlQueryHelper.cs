using Eshop.Domain.Common;
using System.Text;

namespace Eshop.Persistence.Helpers
{
    public static class SqlQueryHelper
    {
        public static string ConvertGetManySpecificationRequestToSql<T>(this GetManyRequestSpecifications<T> request)
        {
            StringBuilder sb = new();

            #region "Filter"

            if (request.FilterByProperty != null)
            {
                sb.Append($"\nWHERE [{request.FilterByProperty}] ");

                switch (request.FilterCriteria.Value)
                {
                    case FilterCriteria.GreaterThen:
                        {
                            var sign = request.FilterExclude == true ? "<" : ">";
                            sb.Append($"{sign} {request.FilterValue1}");
                        }
                        break;
                    case FilterCriteria.GreaterThenOrEqual:
                        {
                            var sign = request.FilterExclude == true ? "<=" : ">=";
                            sb.Append($"{sign} {request.FilterValue1}");
                        }
                        break;
                    case FilterCriteria.LessThen:
                        {
                            var sign = request.FilterExclude == true ? ">" : "<";
                            sb.Append($"{sign} {request.FilterValue1}");
                        }
                        break;
                    case FilterCriteria.LessThenOrEqual:
                        {
                            var sign = request.FilterExclude == true ? ">=" : "<=";
                            sb.Append($"{sign} {request.FilterValue1}");
                        }
                        break;
                    case FilterCriteria.Between:
                        {
                            string not = request.FilterExclude == true ? "NOT" : "";
                            sb.Append($"{not} BETWEEN {request.FilterValue1} AND {request.FilterValue2}");
                        }
                        break;
                    case FilterCriteria.Equal:
                        {
                            var sign = request.FilterExclude == true ? "=" : "<>";
                            sb.Append($"{sign} {request.FilterValue1}");
                        }
                        break;
                    case FilterCriteria.NotEqual:
                        {
                            var sign = request.FilterExclude == true ? "<>" : "=";
                            sb.Append($"{sign} {request.FilterValue1}");
                        }
                        break;
                }
            }

            #endregion "Filter"

            #region "Sort"

            if (request.SortByProperty != null)
            {
                var dir = request.SortByDescending == true ? "DESC" : "";
                sb.Append($"\nORDER BY [{request.SortByProperty}] {dir}");
            }

            #endregion "Sort"

            #region "Skip"

            if (request.Skip.HasValue || request.Take.HasValue)
            {
                var val = request.Skip.HasValue ? request.Skip.Value : 0;
                sb.Append($"\nOFFSET {val} ROWS");
            }

            #endregion "Skip"

            #region "Take"

            if (request.Take.HasValue)
            {
                sb.Append($"\nFETCH NEXT {request.Take.Value} ROWS ONLY");
            }

            #endregion "Take"

            return sb.ToString();
        }
    }
}