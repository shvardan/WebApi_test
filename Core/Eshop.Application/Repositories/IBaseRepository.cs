using Eshop.Application.Features.ProductFeatures.GetAllProducts;
using Eshop.Domain.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Application.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Create(T entity, CancellationToken cancellationToken);
        Task<T> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> Get(T entity, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAll(GetManyRequestSpecifications<T> request, CancellationToken cancellationToken);
        Task<int> GetCount();
    }
}