using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareDesign.lab2.Exceptions;
using SoftwareDesign.lab2.Models;
using SoftwareDesign.lab2.Services;

namespace SoftwareDesign.lab2.Controllers;

[ApiController]
[Route("api/messages")]
public class MessageController(MessageService messageService,UserService userService) : Controller {
	private readonly MessageService _msgService = messageService;
	private readonly UserService _usrService = userService;

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
	[HttpGet]
	public async Task<IActionResult> GetMessagesAsync([FromQuery] Guid channelId,[FromQuery] Guid userId) {
		if (!await this._msgService.ChannelExistsAsync(channelId)) return NotFound("No such channel found.");
		var messages = await this._msgService.GetMessagesAsync(channelId,userId);
		return Ok(messages);
	}
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
	[HttpGet("dms/{userId}")]
	public async Task<IActionResult> GetAllDmsAsync(Guid userId) {
		return Ok(await this._msgService.GetAllChannelsAsync(userId));
	}
	[HttpPut("delete_message")]
	public async Task<IActionResult> DeleteMessageAsync([FromQuery] Guid messageId) {
		try {
			await this._msgService.DeleteMessageAsync(messageId);
			return Ok();
		} catch (InvalidOperationException e) {
			return BadRequest(e.Message);
		}
	}
	[HttpPost("delete_for_me")]
	public async Task<IActionResult> DeleteForMeAsync([FromQuery] Guid messageId,[FromQuery] Guid userId) {
		try {
			await this._msgService.DeleteForMeAsync(messageId,userId);
			return Ok();
		} catch (InvalidOperationException e) {
			return BadRequest(e.Message);
		}
	}
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