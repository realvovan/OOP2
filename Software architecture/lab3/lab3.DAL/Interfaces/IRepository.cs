namespace lab3.DAL.Interfaces;

public interface IRepository<T> where T : class {
	void Add(T entity);
	void Remove(T entity);
	void Update(T entity);
	Task<T?> GetByIdAsync(Guid id);
	Task<IEnumerable<T>> GetAllAsync();
}
