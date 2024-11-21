using PT.Dasigno.DTO.Users;

namespace PT.Dasigno.BLL.Interfaces.Services
{
    public interface IUsersServices
    {
        IEnumerable<UserDto> GetAll();
        IEnumerable<UserDto> Search(SearchUserRequest request);
        UserDto Find(int id);
        UserDto Create(CreateUserRequest request);
        UserDto Update(UpdateUserRequest request);
        bool Delete(int id);
    }
}
