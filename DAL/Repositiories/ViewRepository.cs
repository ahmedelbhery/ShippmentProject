using DAL.Contracts;
using DAL.DBContext;
using DAL.Exeptions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace DAL.Repositiories
{
    public class ViewRepository<T> : IViewRepository<T> where T : class
    {
        private readonly ShipingContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly ILogger<ViewRepository<T>> _logger;

        public ViewRepository(ShipingContext context, ILogger<ViewRepository<T>> logger)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _logger = logger;
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                return await _dbSet.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }

        public async Task<T?> GetById(Guid id)
        {
            try
            {
                // Generic fallback: assumes entity has a property named "Id"
                return await _dbSet
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }

        public async Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            try
            {
                return await _dbSet.Where(filter).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }

        public async Task<List<T>> GetList(Expression<Func<T, bool>> filter)
        {
            try
            {
                return await _dbSet.Where(filter).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }
    }
}
