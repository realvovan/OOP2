using Microsoft.AspNetCore.Mvc;
using SoftwareDesign.lab2.Exceptions;
using SoftwareDesign.lab2.Services;
using SoftwareDesign.lab2.Models;

namespace SoftwareDesign.lab2.Controllers;

/// <summary>
/// API controller for managing user-related operations.
/// Handles user registration, retrieval, and profile updates.
/// </summary>
[ApiController]
[Route("api/users")]
public class UserController(UserService userService) : ControllerBase {
	private readonly UserService _userService = userService;

	/// <summary>
	/// Registers a new user with the provided username.
	/// </summary>
	/// <param name="username">The username of the user to register.</param>
	/// <returns>
	/// Returns 200 OK with the created user if successful,
	/// 400 Bad Request if username is invalid or an error occurs,
	/// or 409 Conflict if the username already exists.
	/// </returns>
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

	/// <summary>
	/// Retrieves user information by username.
	/// </summary>
	/// <param name="username">The username of the user to retrieve.</param>
	/// <returns>
	/// Returns 200 OK with the user object if found,
	/// or 404 Not Found if the user does not exist.
	/// </returns>
	[HttpGet("{username}")]
	public async Task<IActionResult> GetUserFromNameAsync(string username) {
		User? user = await this._userService.GetUserFromUsernameAsync(username);
		if (user is null) return NotFound();
		else return Ok(user);
	}

	/// <summary>
	/// Updates user information including username.
	/// </summary>
	/// <param name="user">The user object containing updated information.</param>
	/// <returns>
	/// Returns 200 OK if the update is successful,
	/// 400 Bad Request if the username is invalid,
	/// or 409 Conflict if the new username already exists.
	/// </returns>
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