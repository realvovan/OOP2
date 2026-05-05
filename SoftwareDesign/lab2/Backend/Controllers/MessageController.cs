using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareDesign.lab2.Exceptions;
using SoftwareDesign.lab2.Models;
using SoftwareDesign.lab2.Services;

namespace SoftwareDesign.lab2.Controllers;

/// <summary>
/// API controller for managing messaging operations.
/// Handles direct messaging, message sending, retrieval, and deletion.
/// </summary>
[ApiController]
[Route("api/messages")]
public class MessageController(MessageService messageService,UserService userService) : ControllerBase {
	private readonly MessageService _msgService = messageService;
	private readonly UserService _usrService = userService;

	/// <summary>
	/// Sends a message to a specific channel.
	/// </summary>
	/// <param name="message">The message object containing SenderId, ChannelId, and Content.</param>
	/// <returns>Returns 200 OK with the sent message if successful, or 400 Bad Request if an error occurs.</returns>
	[HttpPost]
	public async Task<IActionResult> SendMessageAsync([FromBody] Message message) {
		Console.WriteLine($"Sending: {message.Content}");
		try {
			var sent = await this._msgService.SendMessageAsync(message.SenderId,message.ChannelId,message.Content);
			return Ok(sent);
		} catch (InvalidOperationException e) {
			return BadRequest(e.Message);
		}
	}

	/// <summary>
	/// Retrieves all messages from a specific channel.
	/// </summary>
	/// <param name="channelId">The ID of the channel to retrieve messages from.</param>
	/// <param name="userId">The ID of the user requesting the messages.</param>
	/// <returns>Returns 200 OK with the list of messages, or 404 Not Found if the channel does not exist.</returns>
	[HttpGet]
	public async Task<IActionResult> GetMessagesAsync([FromQuery] Guid channelId,[FromQuery] Guid userId) {
		if (!await this._msgService.ChannelExistsAsync(channelId)) return NotFound("No such channel found.");
		var messages = await this._msgService.GetMessagesAsync(channelId,userId);
		return Ok(messages);
	}

	/// <summary>
	/// Creates a direct message channel between two users.
	/// If a DM channel already exists between the users, returns the existing channel.
	/// </summary>
	/// <param name="creatorId">The ID of the user initiating the DM channel creation.</param>
	/// <param name="other">The username of the other user for the DM.</param>
	/// <returns>
	/// Returns 200 OK with the created or existing channel if successful,
	/// or 400 Bad Request if creator ID is invalid, if users are the same, or if the other user doesn't exist.
	/// </returns>
	[HttpPost("create_dm")]
	public async Task<IActionResult> CreateDmChannelAsync([FromQuery] Guid creatorId,[FromQuery] string other) {
		var creator = await this._usrService.GetUserFromGuidAsync(creatorId);
		if (creator is null) return BadRequest("Invalid user id");
		if (creator.Username == other) return BadRequest("Cannot create a dm with yourself");
		var otherUser = await this._usrService.GetUserFromUsernameAsync(other);
		if (otherUser is null) return BadRequest("No user with given username exsist!");
		var channel = await this._msgService.DatabaseContext.Channels
			.FirstOrDefaultAsync(c => 
				this._msgService.DatabaseContext.ChannelMembers.Any(m => m.ChannelId == c.Id && m.UserId == creatorId)
				&& this._msgService.DatabaseContext.ChannelMembers.Any(m => m.ChannelId == c.Id && m.UserId == otherUser.Id)
			);
		if (channel is not null) return Ok(channel);
		channel = await this._msgService.CreateChannelAsync(creatorId);
		await this._msgService.AddChannelMemberAsync(otherUser.Id,channel.Id);
		channel.Members.Add(otherUser);
		return Ok(channel);
	}

	/// <summary>
	/// Retrieves all direct message channels for a specific user.
	/// </summary>
	/// <param name="userId">The ID of the user to retrieve DM channels for.</param>
	/// <returns>Returns 200 OK with the list of all DM channels for the user.</returns>
	[HttpGet("dms/{userId}")]
	public async Task<IActionResult> GetAllDmsAsync(Guid userId) {
		return Ok(await this._msgService.GetAllChannelsAsync(userId));
	}

	/// <summary>
	/// Deletes a message permanently from a channel.
	/// </summary>
	/// <param name="messageId">The ID of the message to delete.</param>
	/// <returns>Returns 200 OK if deletion is successful, or 400 Bad Request if an error occurs.</returns>
	[HttpPut("delete_message")]
	public async Task<IActionResult> DeleteMessageAsync([FromQuery] Guid messageId) {
		try {
			await this._msgService.DeleteMessageAsync(messageId);
			return Ok();
		} catch (InvalidOperationException e) {
			return BadRequest(e.Message);
		}
	}

	/// <summary>
	/// Deletes a message only for a specific user, leaving it visible to others.
	/// </summary>
	/// <param name="messageId">The ID of the message to delete for the user.</param>
	/// <param name="userId">The ID of the user deleting the message.</param>
	/// <returns>Returns 200 OK if deletion is successful, or 400 Bad Request if an error occurs.</returns>
	[HttpPost("delete_for_me")]
	public async Task<IActionResult> DeleteForMeAsync([FromQuery] Guid messageId,[FromQuery] Guid userId) {
		try {
			await this._msgService.DeleteForMeAsync(messageId,userId);
			return Ok();
		} catch (InvalidOperationException e) {
			return BadRequest(e.Message);
		}
	}

	/// <summary>
	/// Updates the typing state of a user in a specific channel.
	/// </summary>
	/// <param name="userId">The ID of the user whose typing state is being updated.</param>
	/// <param name="channelId">The ID of the channel where the typing state is being set.</param>
	/// <param name="state">True if the user is typing, false otherwise.</param>
	/// <returns>Returns 200 OK if the update is successful, or 400 Bad Request if an error occurs.</returns>
	[HttpPost("set_user_typing_state")]
	public async Task<IActionResult> SetUserTypingStateAsync([FromQuery] Guid userId,[FromQuery] Guid channelId,[FromQuery] bool state) {
		try {
			await this._msgService.UpdateUserTypingStateAsync(userId,channelId,state);
			return Ok();
		} catch (Exception e) {
			return BadRequest(e.Message);
		}
	}
}