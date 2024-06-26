﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Infrastructure.Identity.LoginUser;
using OnlineMarket.Infrastructure.Identity.RegisterUser;

namespace OnlineMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator _mediator) 
        : ControllerBase
    {
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterUserCommand registerCommand)
        {
            var result = await _mediator.Send(registerCommand);

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<LoginUserResponse>> Login(LoginUserCommand loginCommand)
        {
            var result = await _mediator.Send(loginCommand);

            if(result.IsFailure)
            {
                return Unauthorized(result.Error);
            }

            return Accepted(result.Body);
        }
    }
}
