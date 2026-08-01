using Microsoft.AspNetCore.Mvc;
using projeto.Services;

namespace projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResilienceController : ControllerBase
    {
        private readonly ExternalService _externalService;

        public ResilienceController(ExternalService externalService)
        {
            _externalService = externalService;
        }

        [HttpGet("test-polly")]
        public async Task<IActionResult> TestPolly()
        {
            try
            {
                var data = await _externalService.GetDataFromExternalApiAsync();
                return Ok(new { Message = "Chamada bem-sucedida com proteção do Polly!", Data = data });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "O serviço externo falhou.", Error = ex.Message });
            }
        }
    }
}