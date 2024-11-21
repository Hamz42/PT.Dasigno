using System.Linq.Expressions;

namespace PT.Dasigno.BLL.Interfaces.Repository.Base
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null!,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!,
                                        string includeProperties = "");
        T? Create(T entity);
        T? Find(int entity);
        T? Update(T entity);
    }
}
