using Microsoft.EntityFrameworkCore;
using PT.Dasigno.BLL.Interfaces.Base;
using PT.Dasigno.BLL.Interfaces.Repository.Base;
using System.Linq.Expressions;

namespace PT.Dasigno.BLL.Persistence.Repository.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork; 

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Método protegido para obtener el DbContext
        protected DbContext GetContext()
        {
            return _unitOfWork.ContextDasigno!;
        }

        public T? Create(T entity)
        {
            try
            {
                _unitOfWork.ContextDasigno.Set<T>().Add(entity);
                _unitOfWork.ContextDasigno.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T? Find(int id)
        {
            return GetContext().Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.ContextDasigno.Set<T>().ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null!, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!, string includeProperties = "")
        {
            IQueryable<T> query = GetContext().Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T? Update(T entity)
        {
            try
            {
                _unitOfWork.ContextDasigno.Set<T>().Update(entity);
                _unitOfWork.ContextDasigno.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
