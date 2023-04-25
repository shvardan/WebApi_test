using AutoMapper;
using Eshop.Application.Repositories;
using Eshop.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Application.Features.ProductFeatures.UpdateProduct
{
    public sealed class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            product.DateModified = DateTimeOffset.UtcNow;
            product = await _unitOfWork.Products.Update(product);
            return _mapper.Map<UpdateProductResponse>(product);
        }
    }
}