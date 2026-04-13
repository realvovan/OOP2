using lab3.DAL.Interfaces;
using lab3.Domain;
using Microsoft.EntityFrameworkCore;

namespace lab3.DAL;

public class EfRepository<T> : IRepository<T> where T : Entity {
	private readonly DbSet<T> _set;

	public void Add(T entity) => this._set.Add(entity);
	public void Remove(T entity) => this._set.Remove(entity);
	public void Update(T entity) => this._set.Update(entity);
	public async Task<T?> GetByIdAsync(Guid id) => await this._set.FindAsync(id);
	public async Task<IEnumerable<T>> GetAllAsync() => await this._set.ToListAsync();
	public EfRepository(DbContext dbContext) {
		this._set = dbContext.Set<T>();
	}
}