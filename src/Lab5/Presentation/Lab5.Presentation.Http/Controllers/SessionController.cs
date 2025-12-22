using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Contracts.Sessions.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("/api/session")]
public sealed class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost("user")]
    public IActionResult CreateUserSession(
        [FromBody] CreateUserSessionOperation.Request request)
    {
        CreateUserSessionOperation.Response response =
            _sessionService.CreateUserSession(request);

        return Ok(response);
    }

    [HttpPost("admin")]
    public IActionResult CreateAdminSession(
        [FromBody] CreateAdminSessionOperation.Request request)
    {
        CreateAdminSessionOperation.Response response =
            _sessionService.CreateAdminSession(request);

        return Ok(response);
    }
}