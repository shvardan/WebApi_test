using Eshop.Application.Repositories;
using Eshop.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IProductRepository productRepository, IStorageService storageSerevice)
        {
            Products = productRepository;
            Storage = storageSerevice;
        }

        public IProductRepository Products { get; }
        public IStorageService Storage { get; }
    }
}
