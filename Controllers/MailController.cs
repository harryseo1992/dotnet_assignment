using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1_v3.Models;
using Assignment1_v3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1_v3.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MailController : ControllerBase
  {
    private readonly IMailService _mailService;
    public MailController(IMailService mailService)
    {
      _mailService = mailService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMail([FromForm] MailRequest request)
    {
      try
      {
        await _mailService.SendEmailAsync(request);
        return Ok();
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    [HttpPost("welcome")]
    public async Task<IActionResult> SendWelcome([FromForm] WelcomeRequest request)
    {
        try
        {
            await _mailService.SendWelcomeEmailAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
  }
}