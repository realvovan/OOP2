using Coursework.BusinessLevel.DTOs;
using Coursework.DataLevel.DataProviders;

namespace Coursework.BusinessLevel.Services;

public class BaseEntityService<T,T_DTO> where T_DTO : IDTO<T> {

	protected Dictionary<Guid,T> entities;
	private Func<T,Guid?,T_DTO> convertFunc;

	public virtual Result AddEntity(T_DTO entity) {
		try {
			this.entities[Guid.NewGuid()] = entity.ToEntity();
			return Result.Successful;
		} catch(Exception e) {
			return Result.Fail($"Could not add entity: {e.Message}");
		}
	}
	public virtual Result RemoveEntity(Guid entityId) {
		bool result = this.entities.Remove(entityId);
		return result ? Result.Successful : Result.Fail("Could not find entity with a given Guid");
	}
	public virtual Result UpdateEntity(T_DTO newEntity) {
		if (newEntity.Guid == null || !this.entities.ContainsKey(newEntity.Guid.Value))
			return Result.Fail("Could not find entity with a given Guid");
		try {
			this.entities[newEntity.Guid.Value] = newEntity.ToEntity();
			return Result.Successful;
		} catch (Exception e) {
			return Result.Fail($"Could not update entity: {e.Message}");
		}
	}
	public virtual Result SaveEntitiesToFile(string filePath) {
		return this.SaveEntitiesToFile(new JsonProvider(filePath));
	}
	public virtual Result SaveEntitiesToFile(IDataProvider provider) {
		try {
			provider.SaveToFile(this.entities);
			return Result.Successful;
		} catch (Exception e) {
			return Result.Fail($"Error while saving objects: {e.Message}");
		}
	}
	public virtual Result LoadEntitiesFromFile(IDataProvider provider) {
		try {
			var loaded = provider.LoadFromFile<Dictionary<Guid,T>>();
			if (loaded == null) return Result.Fail("Provider returned null");
			this.entities = loaded;
			return Result.Successful;
		} catch (Exception e) {
			return Result.Fail($"Error while loading objects: {e.Message}");
		}
	}
	public virtual Result LoadEntitiesFromFile(string filePath) {
		return this.LoadEntitiesFromFile(new JsonProvider(filePath));
	}

	public T_DTO? GetEntityInfo(Guid entityId) {
		if (this.entities.TryGetValue(entityId,out var entity)) return this.convertFunc(entity,entityId);
		return default;
	}
	public bool EntityExists(Guid entityId) => this.entities.ContainsKey(entityId);
	public FilterResult<T_DTO> GetAllEntities() {
		return new FilterResult<T_DTO>(
			this.entities
				.Select(kv => this.convertFunc(kv.Value,kv.Key))
				.ToArray()
		);
	}
	
	public BaseEntityService(Func<T,Guid?,T_DTO> convertFunc) {
		this.entities = new();
		this.convertFunc = convertFunc;
	}
	public BaseEntityService(Dictionary<Guid,T> entities,Func<T,Guid?,T_DTO> convertFunc) {
		this.entities = entities;
		this.convertFunc = convertFunc;
	}
	public BaseEntityService(Dictionary<Guid,T_DTO> entities,Func<T,Guid?,T_DTO> convertFunc) {
		var dict = new Dictionary<Guid,T>(entities.Count);
		foreach (var kv in entities) {
			try {
				dict[kv.Key] = kv.Value.ToEntity();
			} catch(Exception e) {
				Console.WriteLine($"[Warning] {e.Message}");
			}
		}
		this.entities = dict;
		this.convertFunc = convertFunc;
	}
}