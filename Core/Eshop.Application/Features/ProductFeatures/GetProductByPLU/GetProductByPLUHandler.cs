using AutoMapper;
using Eshop.Application.Repositories;
using Eshop.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Application.Features.ProductFeatures.GetProductByPLU
{
    public sealed class GetProductByPLUHandler : IRequestHandler<GetProductByPLURequest, GetProductByPLUResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductByPLUHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetProductByPLUResponse> Handle(GetProductByPLURequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            product = await _unitOfWork.Products.GetByPLU(product, cancellationToken);
            return _mapper.Map<GetProductByPLUResponse>(product);
        }
    }
}