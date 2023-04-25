using AutoMapper;
using Eshop.Application.Repositories;
using Eshop.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Application.Features.ProductFeatures.GetProduct
{
    public sealed class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            product = await _unitOfWork.Products.Get(product, cancellationToken);
            return _mapper.Map<GetProductResponse>(product);
        }
    }
}