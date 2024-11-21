using PT.Dasigno.BLL.Interfaces.Repository.Base;
using PT.Dasigno.DAL.Context.ContextDasigno.Entities;
using PT.Dasigno.DTO.Users;

namespace PT.Dasigno.BLL.Interfaces.Repository
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        IEnumerable<Users> Search(SearchUserRequest request);
        bool Delete(int id);
    }
}
