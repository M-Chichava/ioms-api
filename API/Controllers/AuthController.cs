﻿using System.Threading.Tasks;
using Application.DTOs;
using Application.Features.Auth.Commands.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginDto>> Login(LoginCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("refreshToken")]
        public async Task<ActionResult<LoginDto>> RefreshToken(RefreshTokenCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("logout")]
        public async Task<ActionResult<LoginDto>> Logout(LogoutCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}