using System.Linq;

namespace Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ThorpeContext _context;

        public RepositoryBase(ThorpeContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> All => _context.Set<TEntity>().AsQueryable();

        public void Alterar(params TEntity[] obj)
        {
            _context.Set<TEntity>().UpdateRange(obj);
            _context.SaveChanges();
        }

        public void Excluir(params TEntity[] obj)
        {
            _context.Set<TEntity>().RemoveRange(obj);
            _context.SaveChanges();
        }

        public TEntity Find(int key)
        {
            return _context.Find<TEntity>(key);
        }

        public TEntity FindAll()
        {
            return _context.Find<TEntity>();
        }

        public void Incluir(params TEntity[] obj)
        {
            _context.Set<TEntity>().AddRange(obj);
            _context.SaveChanges();
        }
    }
}
