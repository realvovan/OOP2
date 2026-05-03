using Microsoft.AspNetCore.Mvc;
using SoftwareDesign.lab2.Exceptions;
using SoftwareDesign.lab2.Services;
using SoftwareDesign.lab2.Models;

namespace SoftwareDesign.lab2.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(UserService userService) : ControllerBase {
	private readonly UserService _userService = userService;

	[HttpPost("register")]
	public async Task<IActionResult> RegisterAsync([FromBody] string username) {
		try {
			var user = await this._userService.CreateUserAsync(username);
			return user is null ? BadRequest("Error while creating the user") : Ok(user);
		} catch (UsernameAlreadyExistsException) {
			return Conflict("Username already exists!");
		} catch (FormatException) {
			return BadRequest("Invalid username");
		}
	}
	[HttpGet("{username}")]
	public async Task<IActionResult> GetUserFromNameAsync(string username) {
		User? user = await this._userService.GetUserFromUsernameAsync(username);
		if (user is null) return NotFound();
		else return Ok(user);
	}
	[HttpPut("update_info")]
	public async Task<IActionResult> UpdateUserAsync([FromBody] User user) {
		try {
			await this._userService.UpdateUsernameAsync(user);
			return Ok();
		} catch (UsernameAlreadyExistsException) {
			return Conflict("Username already exists");
		} catch (FormatException) {
			return BadRequest("Invalid username");
		}
	}
}