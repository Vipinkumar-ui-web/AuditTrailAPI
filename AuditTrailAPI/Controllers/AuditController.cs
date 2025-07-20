using AuditTrailAPI.Models;
using AuditTrailAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditTrailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IAuditService _auditService;

        public AuditController(IAuditService auditService)
        {
            _auditService = auditService;
        }
        [HttpPost("track")]
        public async Task<ActionResult<AuditResponse>> TrackChanges([FromBody] AuditRequest request)
        {
            var result = await _auditService.TrackChangesAsync(request);
            return Ok(result);
        }
    }
}
