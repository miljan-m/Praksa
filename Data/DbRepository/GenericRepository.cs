using LibraryApp.CustomExceptions;

namespace LibraryApp.Data.DbRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly LibraryDBContext _context;
    public GenericRepository(LibraryDBContext context)
    {
        _context = context;
    }
    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetOneAsync(string id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> CreateAsync(T objToCreate)
    {
        await _context.AddAsync(objToCreate);
        await _context.SaveChangesAsync();
        return objToCreate;
    }

    public async Task<T> UpdateAsync(T objToBeUpdated, string id)
    {
        var existingObj =await _context.Set<T>().FindAsync(id);
        //_context.Set<T>().Update(objToBeUpdated);
        //_context.Update(objToBeUpdated);
        _context.Entry(existingObj).CurrentValues.SetValues(objToBeUpdated);
        await _context.SaveChangesAsync();
        return objToBeUpdated;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var objToDelete =await _context.Set<T>().FindAsync(id);
        //if (objToDelete == null) throw new NotFoundException($"Object with given id={id} does't exist");// uncomment and check
        _context.Set<T>().Remove(objToDelete);
        await _context.SaveChangesAsync();
        return true;
    }


}