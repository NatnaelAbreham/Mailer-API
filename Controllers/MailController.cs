using MailerApi.Models;
using MailerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MailerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MailController : Controller
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] MailRequest request)
        {
            try
            {
                await _mailService.SendEmailAsync(request);
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Email sent successfully!"
                });
            }
            catch (MailKit.Net.Smtp.SmtpCommandException ex)
            {
                // SMTP command error (e.g., invalid recipient, authentication failed)
                return StatusCode(400, new
                {
                    StatusCode = 400,
                    Message = $"SMTP command error: {ex.Message}"
                });
            }
            catch (MailKit.Security.AuthenticationException ex)
            {
                // Authentication problem
                return StatusCode(401, new
                {
                    StatusCode = 401,
                    Message = $"Authentication failed: {ex.Message}"
                });
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                // Network/server unreachable
                return StatusCode(503, new
                {
                    StatusCode = 503,
                    Message = $"Service unavailable (network issue): {ex.Message}"
                });
            }
            catch (Exception ex)
            {
                // Unexpected error
                return StatusCode(500, new
                {
                    StatusCode = 500,
                    Message = $"Internal server error: {ex.Message}"
                });
            }
        }

    }
}
