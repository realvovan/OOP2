using SoftwareDesign.lab2.Storage;
using SoftwareDesign.lab2.Exceptions;
using SoftwareDesign.lab2.Models;
using SoftwareDesign.lab2.Validators;
using Microsoft.EntityFrameworkCore;

namespace SoftwareDesign.lab2.Services;

public class UserService(DatabaseContext dbContext) {
	private readonly DatabaseContext _db = dbContext;
	private readonly DbSet<User> _users = dbContext.Users;
	public async Task<User?> CreateUserAsync(string username) {
		// if (!UserValidator.ValidateUsername(username)) throw new FormatException("Invalid username format");
		try {
			var user = new User(username);
			this._users.Add(user);
			await this._db.SaveChangesAsync();
			return user;
		} catch (DbUpdateException) {
			Console.WriteLine("+==================HERE");
			throw new UsernameAlreadyExistsException(username);
		}
	}
	public async Task UpdateUsernameAsync(User newUser) {
		if (!UserValidator.ValidateUsername(newUser.Username)) throw new FormatException("Invalid username format");
		if (!UserValidator.ValidateDisplayName(newUser.DisplayName)) throw new FormatException("Invalid display name format");
		if (string.IsNullOrWhiteSpace(newUser.DisplayName)) newUser.DisplayName = newUser.Username;
		newUser.DisplayName = newUser.DisplayName.Trim();
		try {
			var user = await this._db.Users.FindAsync(newUser.Id) ?? throw new InvalidGuidException(newUser.Id);
			user.DisplayName = newUser.DisplayName;
			user.Username = newUser.Username;
			await this._db.SaveChangesAsync();
		} catch (DbUpdateException) {
			throw new UsernameAlreadyExistsException(newUser.Username);
		}
	}
	public async Task<User?> GetUserFromUsernameAsync(string username) {
		return await this._users.FirstOrDefaultAsync(x => x.Username == username);
	}
	public async Task<User?> GetUserFromGuidAsync(Guid guid) {
		return await this._users.FirstOrDefaultAsync(x => x.Id == guid);
	}
}