using AutoMapper;
using Eshop.Application.Repositories;
using Eshop.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Application.Features.ProductFeatures.GetProductByBarcode
{
    public sealed class GetProductByBarcodeHandler : IRequestHandler<GetProductByBarcodeRequest, GetProductByBarcodeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductByBarcodeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetProductByBarcodeResponse> Handle(GetProductByBarcodeRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            product = await _unitOfWork.Products.GetByBarcode(product, cancellationToken);
            return _mapper.Map<GetProductByBarcodeResponse>(product);
        }
    }
}