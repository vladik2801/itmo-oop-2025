using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Application.Contracts.Accounts.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("/api/account")]
public sealed class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("deposit")]
    public IActionResult Deposit([FromBody] DepositOperation.Request request)
    {
        DepositOperation.Response response = _accountService.Deposit(request);
        return Ok(response);
    }

    [HttpPost("withdraw")]
    public IActionResult Withdraw([FromBody] WithdrawOperation.Request request)
    {
        WithdrawOperation.Response response = _accountService.Withdraw(request);
        return Ok(response);
    }

    [HttpPost("create")]
    public IActionResult CreateAccount([FromBody] CreateAccountOperation.Request request)
    {
        CreateAccountOperation.Response response = _accountService.CreateAccount(request);
        return Ok(response);
    }

    [HttpGet("balance")]
    public ActionResult<AccountBalanceModel> GetBalance([FromQuery] Guid sessionId)
    {
        AccountBalanceModel model = _accountService.GetBalance(sessionId);
        return Ok(model);
    }

    [HttpGet("history")]
    public ActionResult<OperationHistoryModel> GetHistory([FromQuery] Guid sessionId)
    {
        OperationHistoryModel model = _accountService.GetHistory(sessionId);
        return Ok(model);
    }
}
