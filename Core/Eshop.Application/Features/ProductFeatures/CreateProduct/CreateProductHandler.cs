using AutoMapper;
using Eshop.Application.Repositories;
using Eshop.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Application.Features.ProductFeatures.CreateProduct
{
    public sealed class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            product.DateCreated = DateTimeOffset.UtcNow;
            product = await _unitOfWork.Products.Create(product, cancellationToken);
            return _mapper.Map<CreateProductResponse>(product);
        }
    }
}