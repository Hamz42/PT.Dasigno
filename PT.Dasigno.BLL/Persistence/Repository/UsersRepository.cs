using PT.Dasigno.BLL.Interfaces.Base;
using PT.Dasigno.BLL.Interfaces.Repository;
using PT.Dasigno.BLL.Persistence.Repository.Base;
using PT.Dasigno.DAL.Context.ContextDasigno.Entities;
using PT.Dasigno.DTO.Users;

namespace PT.Dasigno.BLL.Persistence.Repository
{
    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {
        public UsersRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var model = _unitOfWork.ContextDasigno.Set<Users>().Find(id);

            if (model == null)
            {
                return false;
            }

            _unitOfWork.ContextDasigno.Set<Users>().Remove(model);
            _unitOfWork.Commit();
            return true;
        }

        /// <summary>
        /// Search users by first name and first last name
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IEnumerable<Users> Search(SearchUserRequest request)
        {
            var query = _unitOfWork.ContextDasigno.Set<Users>().AsQueryable();

            if (!string.IsNullOrEmpty(request.FirstName))
            {
                query = query.Where(u => u.FirstName.Contains(request.FirstName));
            }

            if (!string.IsNullOrEmpty(request.FirstLastName))
            {
                query = query.Where(u => u.FirstLastName.Contains(request.FirstLastName));
            }

            return query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
        }
    }
}
