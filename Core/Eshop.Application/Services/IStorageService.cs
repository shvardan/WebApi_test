using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Application.Services
{
    public interface IStorageService
    {
        Task Fill();
        Task Drop();
    }
}
