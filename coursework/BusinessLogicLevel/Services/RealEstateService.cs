using Coursework.BusinessLevel.DTOs;
using Coursework.DataLevel.DataProviders;
using Coursework.DataLevel.Entities;

namespace Coursework.BusinessLevel.Services;

public sealed class RealEstateService : BaseEntityService<RealEstate,RealEstateDTO> {
	private Dictionary<byte,int> roomCounts;
	public override Result AddEntity(RealEstateDTO entity) {
		try {
			this.entities[Guid.NewGuid()] = entity.ToEntity();
		} catch(Exception e) {
			return Result.Fail($"Could not add entity: {e.Message}");
		}
		if (this.roomCounts.ContainsKey(entity.RoomCount)) this.roomCounts[entity.RoomCount]++;
		else this.roomCounts[entity.RoomCount] = 1;
		return Result.Successful;
	}
	public override Result RemoveEntity(Guid entityId) {
		if (!this.entities.TryGetValue(entityId,out var estate)) return Result.Fail("Could not find entity with a given Guid");
		if (this.roomCounts.ContainsKey(estate.RoomCount)) {
			if (this.roomCounts[estate.RoomCount] == 1) this.roomCounts.Remove(estate.RoomCount);
			else this.roomCounts[estate.RoomCount]--;
		}
		return base.RemoveEntity(entityId);
	}
	public override Result UpdateEntity(RealEstateDTO newEntity) {
		if (newEntity.Guid == null || !this.entities.TryGetValue(newEntity.Guid.Value,out var realEstate))
			return Result.Fail("Could not find entity with a given Guid");
		// decriment room count from the old entity
		byte oldCount = realEstate.RoomCount;
		if (this.roomCounts.ContainsKey(oldCount)) {
			if (this.roomCounts[oldCount] == 1) this.roomCounts.Remove(oldCount);
			else this.roomCounts[oldCount]--;
		}
		// update the entity and room counts
		Result result = base.UpdateEntity(newEntity);
		if (!result.Success) return result;
		if (this.roomCounts.ContainsKey(newEntity.RoomCount)) this.roomCounts[newEntity.RoomCount]++;
		else this.roomCounts[newEntity.RoomCount] = 1;
		return Result.Successful;
	}
	public override Result LoadEntitiesFromFile(IDataProvider provider) {
		// try loading from file by calling the method from the base class
		Result result = base.LoadEntitiesFromFile(provider);
		if (!result.Success) return result;
		// update room counts
		this.roomCounts.Clear();
		foreach (var kv in this.entities) {
			if (this.roomCounts.ContainsKey(kv.Value.RoomCount)) this.roomCounts[kv.Value.RoomCount]++;
			else this.roomCounts[kv.Value.RoomCount] = 1;
		}
		return Result.Successful;
	}
	public override Result LoadEntitiesFromFile(string filePath) {
		return this.LoadEntitiesFromFile(new JsonProvider(filePath));
	}
	public byte[] GetExistingRoomCounts() {
		return this.roomCounts
			.Select(kv => kv.Key)
			.ToArray();
	}
	public RealEstateService() : base(RealEstateDTO.FromRealEstate) {
		this.roomCounts = new Dictionary<byte,int>();
	}
	public RealEstateService(Dictionary<Guid,RealEstate> estates) : base(estates,RealEstateDTO.FromRealEstate) {
		var dict = new Dictionary<byte,int>();
		foreach (var kv in estates) {
			if (dict.ContainsKey(kv.Value.RoomCount)) dict[kv.Value.RoomCount]++;
			else dict[kv.Value.RoomCount] = 1;
		}
		this.roomCounts = dict;
	}
	public RealEstateService(Dictionary<Guid,RealEstateDTO> estates) : base(estates,RealEstateDTO.FromRealEstate) {
		var dict = new Dictionary<byte,int>();
		foreach (var kv in estates) {
			if (dict.ContainsKey(kv.Value.RoomCount)) dict[kv.Value.RoomCount]++;
			else dict[kv.Value.RoomCount] = 1;
		}
		this.roomCounts = dict;
	}
}

//public class RealEstateService {
//	internal Dictionary<Guid,RealEstate> estates;
//	private Dictionary<byte,int> roomCounts;

//	public void AddRealEstate(RealEstateDTO estate) {
//		this.estates[Guid.NewGuid()] = estate.ToEntity();
//		if (this.roomCounts.ContainsKey(estate.RoomCount)) this.roomCounts[estate.RoomCount]++;
//		else this.roomCounts[estate.RoomCount] = 1;
//	}
//	public bool RemoveRealEstate(Guid guid) {
//		if (!this.estates.TryGetValue(guid,out var estate)) return false;
//		if (this.roomCounts.ContainsKey(estate.RoomCount)) {
//			if (this.roomCounts[estate.RoomCount] == 1) this.roomCounts.Remove(estate.RoomCount);
//			else this.roomCounts[estate.RoomCount]--;
//		}
//		this.estates.Remove(guid);
//		return true;
//	}
//	public byte[] GetExistingRoomCounts() {
//		return this.roomCounts
//			.Select(kv => kv.Key)
//			.ToArray();
//	}
//	public Result EditRealEstate(RealEstateDTO newRealEstate) {
//		if (newRealEstate.Guid == null || !this.estates.ContainsKey(newRealEstate.Guid.Value))
//			return Result.Fail("Real estate with given Guid does not exist");
//		this.estates[newRealEstate.Guid.Value] = newRealEstate.ToEntity();
//		return Result.Successful;
//	}
//	public RealEstateDTO? GetRealEstateInfo(Guid guid) {
//		if (this.estates.TryGetValue(guid,out var estate)) return RealEstateDTO.FromRealEstate(estate);
//		return null;
//	}
//	public RealEstateDTO[] GetAllRealEstate() {
//		return this.estates
//			.Select(kv => RealEstateDTO.FromRealEstate(kv.Value,kv.Key))
//			.ToArray();
//	}
//	public RealEstateDTO[] GetSortedBy<T>(Func<RealEstateDTO,T> sortingFunc) {
//		return this.estates
//			.Select(kv => RealEstateDTO.FromRealEstate(kv.Value,kv.Key))
//			.OrderBy(sortingFunc)
//			.ToArray();
//	}
//	public RealEstateDTO[] GetDescendingSortedBy<T>(Func<RealEstateDTO,T> sortingFunc) {
//		return this.estates
//			.Select(kv => RealEstateDTO.FromRealEstate(kv.Value,kv.Key))
//			.OrderByDescending(sortingFunc)
//			.ToArray();
//	}
//	public RealEstateDTO[] SearchBy(Func<RealEstateDTO,bool> searchFunc) {
//		return this.estates
//			.Select(kv => RealEstateDTO.FromRealEstate(kv.Value,kv.Key))
//			.Where(searchFunc)
//			.ToArray();
//	}

//	public RealEstateService() {
//		this.estates = new Dictionary<Guid,RealEstate>();
//		this.roomCounts = new Dictionary<byte,int>();
//	}
//	public RealEstateService(Dictionary<Guid,RealEstate> estates) {
//		this.estates = estates;
//		var dict = new Dictionary<byte,int>();
//		foreach (var kv in estates) {
//			if (dict.ContainsKey(kv.Value.RoomCount)) dict[kv.Value.RoomCount]++;
//			else dict[kv.Value.RoomCount] = 1;
//		}
//		this.roomCounts = dict;
//	}
//	public RealEstateService(Dictionary<Guid,RealEstateDTO> estates) {
//		var estateDict = new Dictionary<Guid,RealEstate>(estates.Count);
//		foreach (var kv in estates) {
//			estateDict[kv.Key] = kv.Value.ToEntity();
//		}
//		this.estates = estateDict;
//		var countDict = new Dictionary<byte,int>();
//		foreach (var kv in estates) {
//			if (countDict.ContainsKey(kv.Value.RoomCount)) countDict[kv.Value.RoomCount]++;
//			else countDict[kv.Value.RoomCount] = 1;
//		}
//		this.roomCounts = countDict;
//	}
//}