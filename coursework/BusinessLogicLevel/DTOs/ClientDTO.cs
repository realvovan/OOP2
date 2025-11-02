using Coursework.DataLevel.Entities;

namespace Coursework.BusinessLevel.DTOs;

public class ClientDTO (
	string firstName,
	string lastName,
	string email,
	string phone,
	string passport,
	string iban,
	double desiredPrice,
	byte desiredRoomCount,
	string photoPath,
	List<Guid> suggestedRealEstates,
	DateTime? createdAt = null,
	Guid? guid = null
) : IDTO<Client> {
	public string FirstName { get; set; } = firstName;
	public string LastName { get; set; } = lastName;
	public string Email { get; set; } = email;
	public string PhoneNumber { get; set; } = phone;
	public string PassportNumber { get; set; } = passport;
	public string IBAN { get; set; } = iban;
	public double DesiredPrice { get; set; } = desiredPrice;
	public byte DesiredRoomCount { get; set; } = desiredRoomCount;
	public string PhotoFilePath { get; set; } = photoPath;
	public List<Guid> SuggestedRealEstates { get; set; } = suggestedRealEstates;
	public DateTime? CreatedAt { get; init; } = createdAt;
	public Guid? Guid { get; init; } = guid;

	/// <summary>
	/// Converts the DTO to <see cref="Client"/>
	/// </summary>
	public Client ToEntity() => new Client(
		FirstName,
		LastName,
		Email,
		PhoneNumber,
		PassportNumber,
		IBAN,
		DesiredPrice,
		DesiredRoomCount,
		SuggestedRealEstates,
		PhotoFilePath
	);
	// needed for the non-generic interface
	object IDTO.ToEntity() => this.ToEntity();

	public override string ToString() => $"{FirstName} {LastName} ({Email} | {PhoneNumber})";

	/// <summary>
	/// Creates a new <see cref="ClientDTO"/> from a provided client object
	/// </summary>
	/// <param name="client">Client which will converted to the DTO</param>
	/// <param name="guid">Optional Guid, if the client has it</param>
	public static ClientDTO FromClient(Client client,Guid? guid = null) => new ClientDTO(
		client.FirstName,
		client.LastName,
		client.Email,
		client.PhoneNumber,
		client.Passport,
		client.IBAN,
		client.DesiredPrice,
		client.DesiredRoomCount,
		client.PhotoFilePath,
		client.SuggestedRealEstates,
		client.CreatedAt,
		guid
	);
}