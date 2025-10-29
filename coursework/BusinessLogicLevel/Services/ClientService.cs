using Coursework.BusinessLevel.DTOs;
using Coursework.DataLevel.Entities;

namespace Coursework.BusinessLevel.Services;

public sealed class ClientService : BaseEntityService<Client,ClientDTO> {
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
	public Result RemoveSuggestion(Guid clientGuid,Guid objectGuid) {
		if (!this.entities.TryGetValue(clientGuid,out var client)) return Result.Fail("Client with given Guid does not exist");
		bool result = client.RemoveSuggestion(objectGuid);
		return result ? Result.Successful : Result.Fail("Could not find object with a given Guid");
	}
	public ClientService() : base(ClientDTO.FromClient) { }
	public ClientService(Dictionary<Guid,Client> clients) : base(clients,ClientDTO.FromClient) { }
	public ClientService(Dictionary<Guid,ClientDTO> clients) : base(clients,ClientDTO.FromClient) { }
}

//public class ClientService {
//	public const int MAX_SUGGESTIONS = Client.MAX_SUGGESTIONS;

//	private Dictionary<Guid,Client> clients;

//	public void AddClient(ClientDTO client) => this.clients[Guid.NewGuid()] = client.ToEntity();
//	public bool RemoveClient(Guid clientGuid) => this.clients.Remove(clientGuid);
//	public Result AddSuggestion(Guid clientGuid,Guid objectGuid) {
//		if (!this.clients.TryGetValue(clientGuid,out var client)) return Result.Fail("Client with given Guid does not exist");
//		if (client.SuggestedRealEstates.Count > MAX_SUGGESTIONS) return Result.Fail($"Cannot add more that {MAX_SUGGESTIONS} suggestions");
//		if (client.SuggestedRealEstates.Contains(objectGuid)) return Result.Fail("Real estate already added to suggestions");
//		//also check if real estate exists
//		client.SuggestedRealEstates.Add(objectGuid);
//		return Result.Successful;
//	}
//	public Result RemoveSuggestion(Guid clientGuid,Guid objectGuid) {
//		if (!this.clients.TryGetValue(clientGuid,out var client)) return Result.Fail("Client with given Guid does not exist");
//		bool result = client.SuggestedRealEstates.Remove(objectGuid);
//		return result ? Result.Successful : Result.Fail("Could not find object with a given Guid");
//	}
//	public Result EditClient(ClientDTO newClientInfo) {
//		if (newClientInfo.Guid == null || !this.clients.ContainsKey(newClientInfo.Guid.Value))
//			return Result.Fail("Client with given Guid does not exist");
//		this.clients[newClientInfo.Guid.Value] = newClientInfo.ToEntity();
//		return Result.Successful;
//	}
//	public ClientDTO? GetClientInfo(Guid guid) {
//		if (this.clients.TryGetValue(guid,out var client)) return ClientDTO.FromClient(client,guid);
//		return null;
//	}
//	public ClientDTO[] GetAllClients() {
//		return this.clients
//			.Select(kv => ClientDTO.FromClient(kv.Value,kv.Key))
//			.ToArray();
//	}
//	public ClientDTO[] GetSortedBy<T>(Func<ClientDTO,T> sortingFunc) {
//		return this.clients
//			.Select(kv => ClientDTO.FromClient(kv.Value,kv.Key))
//			.OrderBy(sortingFunc)
//			.ToArray();
//	}
//	public ClientDTO[] GetDescendingSortedBy<T>(Func<ClientDTO,T> sortingFunc) {
//		return this.clients
//			.Select(kv => ClientDTO.FromClient(kv.Value,kv.Key))
//			.OrderByDescending(sortingFunc)
//			.ToArray();
//	}
//	public ClientDTO[] SearchBy(Func<ClientDTO,bool> searchFunc) {
//		return this.clients
//			.Select(kv => ClientDTO.FromClient(kv.Value,kv.Key))
//			.Where(searchFunc)
//			.ToArray();
//	}

//	public ClientService() {
//		this.clients = new Dictionary<Guid,Client>();
//	}
//	public ClientService(Dictionary<Guid,Client> clients) {
//		this.clients = clients;
//	}
//	public ClientService(Dictionary<Guid,ClientDTO> clients) {
//		var dict = new Dictionary<Guid,Client>(clients.Count);
//		foreach (var kv in clients) {
//			dict[kv.Key] = kv.Value.ToEntity();
//		}
//		this.clients = dict;
//	}
//}