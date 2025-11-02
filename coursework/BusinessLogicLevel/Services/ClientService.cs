using Coursework.BusinessLevel.DTOs;
using Coursework.DataLevel.Entities;

namespace Coursework.BusinessLevel.Services;

/// <summary>
/// Service for working with realtor clients
/// </summary>
public sealed class ClientService : BaseEntityService<Client,ClientDTO> {
	/// <summary>
	/// Maximum number of real estate suggestions, that can be added to a single client
	/// </summary>
	public const int MAX_SUGGESTIONS = Client.MAX_SUGGESTIONS; // exists for PresentationLevel
	/// <summary>
	/// Attempts to add a real estate suggestion to a client with a given Guid and returns whether it was successful
	/// </summary>
	/// <param name="clientGuid">Client's Guid</param>
	/// <param name="objectGuid">Real estate's Guid</param>
	/// <param name="reService"><see cref="RealEstateService"/> which validates <paramref name="objectGuid"/></param>
	/// <returns>
	/// A failed result is returned if a client or real estate with a provided Guid does not exist
	/// or if the client has too many suggestions
	/// </returns>
	public Result AddSuggestion(Guid clientGuid,Guid objectGuid,RealEstateService reService) {
		if (!this.entities.TryGetValue(clientGuid,out var client)) return Result.Fail("Client with given Guid does not exist");
		if (!reService.EntityExists(objectGuid)) return Result.Fail("Real estate with given Guid does not exist");
		try {
			client.AddSuggestion(objectGuid);
		} catch (Exception e) {
			return Result.Fail(e.Message);
		}
		return Result.Successful;
	}
	/// <summary>
	/// Attempts to remove a real estate suggestion for a client and returns the success of the operation
	/// </summary>
	/// <param name="clientGuid">Client's Guid</param>
	/// <param name="objectGuid">Suggested real estate's Guid</param>
	/// <returns>
	/// A failed result is returned if a client with a provided Guid does not exist
	/// or a real estate with a provided Guid is not present in the suggestions list of the client
	/// </returns>
	public Result RemoveSuggestion(Guid clientGuid,Guid objectGuid) {
		if (!this.entities.TryGetValue(clientGuid,out var client)) return Result.Fail("Client with given Guid does not exist");
		bool result = client.RemoveSuggestion(objectGuid);
		return result ? Result.Successful : Result.Fail("Could not find object with a given Guid");
	}
	/// <summary>
	/// Returns the number real estate suggestion a client with a given Guid has.
	/// Returns -1 if a client with that Guid cannot be found
	/// </summary>
	/// <param name="clientGuid">Client's Guid</param>
	public int GetNumberOfSuggestions(Guid clientGuid) {
		if (!this.entities.TryGetValue(clientGuid,out var client)) return -1;
		return client.SuggestedRealEstates.Count;
	}
	/// <summary>
	/// Creates a <see cref="ClientService"/> with no clients
	/// </summary>
	public ClientService() : base(ClientDTO.FromClient) { }
	/// <summary>
	/// Creates a <see cref="ClientService"/> with given entities
	/// </summary>
	public ClientService(Dictionary<Guid,Client> clients) : base(clients,ClientDTO.FromClient) { }
	/// <summary>
	/// Creates <see cref="ClientService"/> with entities from given DTOs
	/// </summary>
	public ClientService(Dictionary<Guid,ClientDTO> clients) : base(clients,ClientDTO.FromClient) { }
}