﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Features.Auth.Command.Login;
using OnionArchitecture.Application.Features.Auth.Command.RefreshToken;
using OnionArchitecture.Application.Features.Auth.Command.Register;

namespace OnionArchitecture.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController :ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response=await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK,response);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
