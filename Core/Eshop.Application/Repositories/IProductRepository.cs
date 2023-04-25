using Eshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Application.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetByBarcode(Product product, CancellationToken cancellationToken);
        Task<Product> GetByPLU(Product product, CancellationToken cancellationToken);
    }
}
