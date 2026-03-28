using Microsoft.AspNetCore.Mvc;
using SoftwareDesign.lab2.Services;

namespace SoftwareDesign.lab2.Controllers;

[ApiController]
[Route("api/audit")]
public class AuditLogController(AuditLogService auditLogService) : Controller {
	private readonly AuditLogService _auditService = auditLogService;

	[HttpGet]
	public async Task<IActionResult> GetEntriesAsync(
		[FromQuery] int limit = 100,
		[FromQuery] int offset = 0,
		[FromQuery] Guid? userId = null
	) {
		if (userId is null) {
			return Ok(await this._auditService.GetAllEntriesAsync(limit,offset));
		} else {
			return Ok(await this._auditService.GetEntriesForUserAsync(userId.Value,limit,offset));
		}
	}
}
