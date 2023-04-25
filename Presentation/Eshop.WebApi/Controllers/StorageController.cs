using Eshop.Application.Features.Storage.DropStorage;
using Eshop.Application.Features.Storage.FillStorage;
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
    public class StorageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StorageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<FillStorageResponse>> Fill()
        {
            var response = await _mediator.Send(new FillStorageRequest());
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<DropStorageResponse>> Drop()
        {
            var response = await _mediator.Send(new DropStorageRequest());
            return Ok(response);
        }
    }
}
