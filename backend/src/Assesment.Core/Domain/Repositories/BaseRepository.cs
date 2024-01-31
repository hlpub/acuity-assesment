using Library.Core.DbContexts;
using Library.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Core.Domain.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : ModelBase
    {
        private readonly LibraryDbContext _libraryDbContext;

        public BaseRepository(LibraryDbContext libraryDbContext)
        {
            ArgumentNullException.ThrowIfNull(libraryDbContext, nameof(libraryDbContext));

            _libraryDbContext = libraryDbContext;
        }
        public virtual async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _libraryDbContext.Set<T>().FindAsync(id, cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken)
        {
            return await _libraryDbContext.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> searchPredicate, CancellationToken cancellationToken)
        {
            return await _libraryDbContext.Set<T>()
                .AsNoTracking().Where(searchPredicate).ToListAsync(cancellationToken);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> searchPredicate, CancellationToken cancellationToken)
        {
            return await _libraryDbContext.Set<T>()
                .AsNoTracking().AnyAsync(searchPredicate);
        }

        public virtual async Task<int> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            _libraryDbContext.Set<T>().Add(entity);

            await _libraryDbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var objBook = await GetByIdAsync(id, cancellationToken);

            if (objBook is null)
                throw new Exception($"Delete failed. No book was found for ID {id}");

            _libraryDbContext.Remove(objBook);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _libraryDbContext?.SaveChangesAsync(cancellationToken);
        }
    }
}
