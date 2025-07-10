using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

public class AuthController : ApiController
{
    // GET
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    
    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterCommand registerCommand, CancellationToken cancellationToken)
    {
        MessageResponse messageResponse = await _mediator.Send(registerCommand, cancellationToken);
        return Ok(messageResponse);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginCommand loginCommand, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _mediator.Send(loginCommand, cancellationToken);
        return Ok(response);
    }
    
}