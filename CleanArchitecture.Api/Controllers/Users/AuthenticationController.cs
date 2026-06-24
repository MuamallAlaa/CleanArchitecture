using CleanArchitecture.Application.Users.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers.Users;

[ApiController]
[Route("Auth")]
public class AuthenticationController(ISender sender) : ControllerBase
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterUserCommand requestCommand, CancellationToken cancellationToken)
    {
        var result = await sender.Send(requestCommand, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result);
    }
}