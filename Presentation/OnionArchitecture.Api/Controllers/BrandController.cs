using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Features.Brands.Commands.CreateBrand;
using OnionArchitecture.Application.Features.Brands.Queries.GetAllBrands;

namespace OnionArchitecture.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> GetAllBrands()
        {
            var respnse = await _mediator.Send(new GetAllBrandsQueryRequest());
            return Ok(respnse);
        }
    }
}
