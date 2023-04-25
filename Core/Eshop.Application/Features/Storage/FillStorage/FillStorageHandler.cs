using Eshop.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Application.Features.Storage.FillStorage
{
    public sealed class FillStorageHandler : IRequestHandler<FillStorageRequest, FillStorageResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FillStorageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FillStorageResponse> Handle(FillStorageRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Storage.Fill();
            return new FillStorageResponse();
        }
    }
}