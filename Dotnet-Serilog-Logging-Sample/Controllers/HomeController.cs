using Microsoft.AspNetCore.Mvc;

namespace Dotnet_Serilog_Logging_Sample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    { 
        private readonly ILogger<HomeController> _logger;
          
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("trigger")]
        public IActionResult Trigger()
        {
            throw new Exception("Test exception");
        }
          
        [HttpGet("slow")]
        public async Task<IActionResult> SlowEndpoint()
        {
            _logger.LogInformation("⏳ Slow endpoint started");
            await Task.Delay(2000); // 2 saniye bekle
            _logger.LogInformation("✅ Slow endpoint completed");
            return Ok("Yavaş işlem tamamlandı!");
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUser(int userId)
        {
            _logger.LogInformation("👤 User {UserId} requested", userId);

            if (userId <= 0)
            {
                _logger.LogWarning("⚠️ Invalid user ID: {UserId}", userId);
                return BadRequest("Geçersiz kullanıcı ID");
            }

            _logger.LogInformation("✅ User {UserId} data returned successfully", userId);
            return Ok(new { UserId = userId, Name = $"User{userId}", Status = "Active" });
        }
         
    }
}
