using Eshop.Application.Features.ProductFeatures.CreateProduct;
using Eshop.Application.Features.ProductFeatures.DeleteProduct;
using Eshop.Application.Features.ProductFeatures.GetAllProducts;
using Eshop.Application.Features.ProductFeatures.GetProduct;
using Eshop.Application.Features.ProductFeatures.GetProductByBarcode;
using Eshop.Application.Features.ProductFeatures.GetProductByPLU;
using Eshop.Application.Features.ProductFeatures.GetProductCount;
using Eshop.Application.Features.ProductFeatures.UpdateProduct;
using Eshop.Domain.Common;
using Eshop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductResponse>> Create(CreateProductRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<UpdateProductResponse>> Update(UpdateProductRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<DeleteProductResponse>> Delete(DeleteProductRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<GetProductResponse>> Get(GetProductRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<GetProductByBarcodeResponse>> GetByBarcode(GetProductByBarcodeRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<GetProductByPLUResponse>> GetByPLU(GetProductByPLURequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<GetAllProductResponse>>> GetAll(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<GetProductCountResponse>> GetCount()
        {
            var response = await _mediator.Send(new GetProductCountRequest());
            return Ok(response);
        }
    }
}