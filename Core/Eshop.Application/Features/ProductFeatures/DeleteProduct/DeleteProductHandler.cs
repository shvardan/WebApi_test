using AutoMapper;
using Eshop.Application.Repositories;
using Eshop.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Application.Features.ProductFeatures.DeleteProduct
{
    public sealed class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            bool success = await _unitOfWork.Products.Delete(product);
            return new DeleteProductResponse(success);
        }
    }
}