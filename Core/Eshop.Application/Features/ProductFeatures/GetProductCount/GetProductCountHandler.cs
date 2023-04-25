using AutoMapper;
using Eshop.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Application.Features.ProductFeatures.GetProductCount
{
    public sealed class GetProductCountHandler : IRequestHandler<GetProductCountRequest, GetProductCountResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductCountHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetProductCountResponse> Handle(GetProductCountRequest request, CancellationToken cancellationToken)
        {
            var count = await _unitOfWork.Products.GetCount();
            return new GetProductCountResponse(count);
        }
    }
}