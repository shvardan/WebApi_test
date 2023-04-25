using AutoMapper;
using Eshop.Application.Repositories;
using Eshop.Domain.Common;
using Eshop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Application.Features.ProductFeatures.GetAllProducts
{
    public sealed class GetAllProductHandler : IRequestHandler<GetAllProductRequest, List<GetAllProductResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllProductResponse>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Products.GetAll(request, cancellationToken);
            return _mapper.Map<List<GetAllProductResponse>>(products);
        }
    }
}