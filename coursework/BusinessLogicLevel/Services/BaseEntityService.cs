using Coursework.BusinessLevel.DTOs;
using Coursework.DataLevel.DataProviders;

namespace Coursework.BusinessLevel.Services;

/// <summary>
/// A base class for entity services, meant to be inherited and <see cref="convertFunc"/>
/// set to a function which converts <typeparamref name="T_DTO"/> to <typeparamref name="T"/> objects
/// </summary>
/// <typeparam name="T">Type of entities to be proccessed by the service</typeparam>
/// <typeparam name="T_DTO">Type of DTOs for entities, which must implement <see cref="IDTO{T}"/></typeparam>
public class BaseEntityService<T,T_DTO> where T_DTO : IDTO<T> {

	protected Dictionary<Guid,T> entities;
	private Func<T,Guid?,T_DTO> convertFunc;

	/// <summary>
	/// Gets the number of entities managed by the service
	/// </summary>
	public int Count => this.entities.Count;

	/// <summary>
	/// Attempts to add a new entity to the service and returns whether it was added successfully
	/// </summary>
	/// <param name="entity">DTO of the entity to add</param>
	public Result AddEntity(T_DTO entity) {
		try {
			this.entities[Guid.NewGuid()] = entity.ToEntity();
			return Result.Successful;
		} catch(Exception e) {
			return Result.Fail($"Could not add entity: {e.Message}");
		}
	}
	/// <summary>
	/// Attempts to remove an entity from the service and returns whether it was removed successfully
	/// </summary>
	/// <param name="entityId">Guid of the entity to remove</param>
	public Result RemoveEntity(Guid entityId) {
		bool result = this.entities.Remove(entityId);
		return result ? Result.Successful : Result.Fail("Could not find entity with a given Guid");
	}
	/// <summary>
	/// Attempts to update an entity and returns whether it was edited successfully
	/// </summary>
	/// <param name="newEntity">DTO with new properties for the edited entity. <see cref="T_DTO.Guid"/> must be a non-null value</param>
	public Result UpdateEntity(T_DTO newEntity) {
		if (newEntity.Guid == null || !this.entities.ContainsKey(newEntity.Guid.Value))
			return Result.Fail("Could not find entity with a given Guid");
		try {
			this.entities[newEntity.Guid.Value] = newEntity.ToEntity();
			return Result.Successful;
		} catch (Exception e) {
			return Result.Fail($"Could not update entity: {e.Message}");
		}
	}
	/// <summary>
	/// Attempts to save all entities to a file using <see cref="JsonProvider"/> and returns the success of the operation
	/// </summary>
	/// <param name="filePath">Path to the file to save entites to</param>
	public Result SaveEntitiesToFile(string filePath) {
		return this.SaveEntitiesToFile(new JsonProvider(filePath));
	}
	/// <summary>
	/// Attempts to save all entities using a given DataProvider and returns the success of the operation
	/// </summary>
	/// <param name="provider">DataProvider to serealize and save entities to the file</param>
	public Result SaveEntitiesToFile(IDataProvider provider) {
		try {
			provider.SaveToFile(this.entities);
			return Result.Successful;
		} catch (Exception e) {
			return Result.Fail($"Error while saving objects: {e.Message}");
		}
	}
	/// <summary>
	/// Attempts to load entities from a file using a given DataProvider and returns the success of the operation
	/// </summary>
	/// <param name="provider">DataProvider to deserealize entities</param>
	public Result LoadEntitiesFromFile(IDataProvider provider) {
		try {
			var loaded = provider.LoadFromFile<Dictionary<Guid,T>>();
			if (loaded == null) return Result.Fail("Provider returned null");
			this.entities = loaded;
			return Result.Successful;
		} catch (Exception e) {
			return Result.Fail($"Error while loading objects: {e.Message}");
		}
	}
	/// <summary>
	/// Attempts to load entities from a file using <see cref="JsonProvider"/> and returns the success of the operation
	/// </summary>
	/// <param name="filePath">Path to the file with entities</param>
	public Result LoadEntitiesFromFile(string filePath) {
		return this.LoadEntitiesFromFile(new JsonProvider(filePath));
	}
	/// <summary>
	/// Returns a DTO for an entity or <see langword="null"/> if the entity cannnot be found
	/// </summary>
	/// <param name="entityId">Guid of the entity</param>
	public T_DTO? GetEntityInfo(Guid entityId) {
		if (this.entities.TryGetValue(entityId,out var entity)) return this.convertFunc(entity,entityId);
		return default;
	}
	/// <summary>
	/// Checks whether an object with a given Guid exists in the service
	/// </summary>
	public bool EntityExists(Guid entityId) => this.entities.ContainsKey(entityId);
	/// <summary>
	/// Returns a <see cref="FilterResult{T_DTO}"/> with the DTOs of all entities in the service.
	/// This can be used to get sorted and filtered entities
	/// </summary>
	public FilterResult<T_DTO> GetAllEntities() {
		return new FilterResult<T_DTO>(
			this.entities
				.Select(kv => this.convertFunc(kv.Value,kv.Key))
				.ToArray()
		);
	}

	/// <summary>
	/// Creates a <see cref="BaseEntityService{T, T_DTO}"/> with no entities
	/// </summary>
	/// <param name="convertFunc">Function which converts <typeparamref name="T"/> to <typeparamref name="T_DTO"/> objects</param>
	public BaseEntityService(Func<T,Guid?,T_DTO> convertFunc) {
		this.entities = new();
		this.convertFunc = convertFunc;
	}
	/// <summary>
	/// Creates a <see cref="BaseEntityService{T, T_DTO}"/> with set entities
	/// </summary>
	/// <param name="entities">Entities which will be loaded into the service</param>
	/// <param name="convertFunc">Function which converts <typeparamref name="T"/> to <typeparamref name="T_DTO"/> objects</param>
	public BaseEntityService(Dictionary<Guid,T> entities,Func<T,Guid?,T_DTO> convertFunc) {
		this.entities = entities;
		this.convertFunc = convertFunc;
	}
	/// <summary>
	/// Creates a <see cref="BaseEntityService{T, T_DTO}"/> with set entities from their DTO.
	/// Any DTOs which cannot be converted to <typeparamref name="T"/> will be skipped
	/// </summary>
	/// <param name="entities">Entity DTOs which will be loaded into the service</param>
	/// <param name="convertFunc">Function which converts <typeparamref name="T"/> to <typeparamref name="T_DTO"/> objects</param>
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