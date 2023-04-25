using Eshop.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Application.Features.Storage.DropStorage
{
    public sealed class DropStorageHandler : IRequestHandler<DropStorageRequest, DropStorageResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DropStorageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DropStorageResponse> Handle(DropStorageRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Storage.Drop();
            return new DropStorageResponse();
        }
    }
}