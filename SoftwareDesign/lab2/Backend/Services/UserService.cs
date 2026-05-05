using SoftwareDesign.lab2.Storage;
using SoftwareDesign.lab2.Exceptions;
using SoftwareDesign.lab2.Models;
using SoftwareDesign.lab2.Validators;
using Microsoft.EntityFrameworkCore;

namespace SoftwareDesign.lab2.Services;

/// <summary>
/// Service for managing user-related operations.
/// Handles user creation, updates, and retrieval from the database.
/// </summary>
public class UserService(DatabaseContext dbContext) {
	private readonly DatabaseContext _db = dbContext;
	private readonly DbSet<User> _users = dbContext.Users;

	/// <summary>
	/// Creates a new user with the specified username.
	/// </summary>
	/// <param name="username">The username for the new user.</param>
	/// <returns>Returns the created User object if successful.</returns>
	/// <exception cref="UsernameAlreadyExistsException">Thrown when the username already exists in the database.</exception>
	/// <exception cref="FormatException">Thrown when the username format is invalid.</exception>
	public async Task<User?> CreateUserAsync(string username) {
		// if (!UserValidator.ValidateUsername(username)) throw new FormatException("Invalid username format");
		try {
			var user = new User(username);
			this._users.Add(user);
			await this._db.SaveChangesAsync();
			return user;
		} catch (DbUpdateException) {
			throw new UsernameAlreadyExistsException(username);
		}
	}

	/// <summary>
	/// Updates an existing user's username and display name.
	/// </summary>
	/// <param name="newUser">The user object containing updated username and display name information.</param>
	/// <exception cref="FormatException">Thrown when the username or display name format is invalid.</exception>
	/// <exception cref="InvalidGuidException">Thrown when the user ID is not found in the database.</exception>
	/// <exception cref="UsernameAlreadyExistsException">Thrown when the new username already exists in the database.</exception>
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

	/// <summary>
	/// Retrieves a user by their username.
	/// </summary>
	/// <param name="username">The username to search for.</param>
	/// <returns>Returns the User object if found; otherwise returns null.</returns>
	public async Task<User?> GetUserFromUsernameAsync(string username) {
		return await this._users.FirstOrDefaultAsync(x => x.Username == username);
	}

	/// <summary>
	/// Retrieves a user by their unique identifier (GUID).
	/// </summary>
	/// <param name="guid">The unique identifier (GUID) of the user to retrieve.</param>
	/// <returns>Returns the User object if found; otherwise returns null.</returns>
	public async Task<User?> GetUserFromGuidAsync(Guid guid) {
		return await this._users.FirstOrDefaultAsync(x => x.Id == guid);
	}
}