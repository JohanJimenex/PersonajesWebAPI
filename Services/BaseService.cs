
using Microsoft.EntityFrameworkCore;

namespace PersonajesWebAPI.Services;

public abstract class BaseService<T> where T : class {

    protected readonly PersonajeDbContext _context;

    public BaseService(PersonajeDbContext context) {
        _context = context;
    }

    public async Task<List<T>> GetAll() {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id) {
        var entity = await _context.FindAsync<T>(id) ?? throw new KeyNotFoundException($"Entity with id {id} not found.");
        return entity;
    }

    public async Task<List<T>> GetAllAsync() {
        return await _context.Set<T>().ToListAsync();
    }

    public T Create(T entity) {
        _context.Add(entity);
        _context.SaveChanges();
        return entity;
    }

}