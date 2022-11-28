using Resort.ng.Data;
using Resort.ng.Repository.IRepository;

namespace Resort.ng.Repository
{
    public class Repository : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet=_db.Set
        }

        public async Task CreateAsync(Resorts entity)
        {
            await _db.Resorts_Db.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<Resorts> GetAsync(Expression<Func<Resorts, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Resorts> query = _db.Resorts_Db;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Resorts>> GetAllAsync(Expression<Func<Resorts, bool>> filter = null)
        {
            IQueryable<Resorts> query = _db.Resorts_Db;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task RemoveAsync(Resorts entity)
        {
            _db.Resorts_Db.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Resorts entity)
        {
            _db.Resorts_Db.Update(entity);
            await SaveAsync();
        }
    }
}
