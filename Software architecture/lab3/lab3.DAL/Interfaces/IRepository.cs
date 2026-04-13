using lab3.Domain;

namespace lab3.DAL.Interfaces;

public interface IRepository<T> where T : Entity {
	void Add(T entity);
	void Remove(T entity);
	void Update(T entity);
	Task<T?> GetByIdAsync(Guid id);
	Task<IEnumerable<T>> GetAllAsync();
}
