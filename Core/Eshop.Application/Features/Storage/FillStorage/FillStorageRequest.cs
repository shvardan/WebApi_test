using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Application.Features.Storage.FillStorage
{
    public sealed record FillStorageRequest : IRequest<FillStorageResponse>;
}
