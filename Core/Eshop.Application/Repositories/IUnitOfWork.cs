using Eshop.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Application.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IStorageService Storage { get; }
    }
}
