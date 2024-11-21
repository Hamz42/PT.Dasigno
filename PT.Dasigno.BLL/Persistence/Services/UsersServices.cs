using AutoMapper;
using PT.Dasigno.BLL.Interfaces.Repository;
using PT.Dasigno.BLL.Interfaces.Services;
using PT.Dasigno.DAL.Context.ContextDasigno.Entities;
using PT.Dasigno.DTO.Users;

namespace PT.Dasigno.BLL.Persistence.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersServices(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserDto Create(CreateUserRequest request)
        {
            var model = _usersRepository.Create(new Users
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                FirstLastName = request.FirstLastName,
                SecondLastName = request.SecondLastName,
                Birthdate = request.Birthdate,
                Salary = request.Salary,
                CreationDate = DateTime.Now
            });

            return _mapper.Map<UserDto>(model);
        }

        /// <summary>
        /// Find user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserDto Find(int id)
        {
            var model = _usersRepository.Find(id);
            return _mapper.Map<UserDto>(model);
        }

        /// <summary>
        /// Search users by first name and first last name
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IEnumerable<UserDto> Search(SearchUserRequest request)
        {
            var models = _usersRepository.Search(request);
            return _mapper.Map<IEnumerable<UserDto>>(models);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDto> GetAll()
        {
            var models = _usersRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(models);
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public UserDto Update(UpdateUserRequest request)
        {
            var model = _usersRepository.Find(request.Id);
            
            if (model == null)
            {
                throw new Exception("User not found");
            }

            model.FirstName = request.FirstName;
            model.MiddleName = request.MiddleName;
            model.FirstLastName = request.FirstLastName;
            model.SecondLastName = request.SecondLastName;
            model.Birthdate = request.Birthdate;
            model.Salary = request.Salary;
            model.ModificationDate = DateTime.Now;
            
            var updatedModel = _usersRepository.Update(model);
            return _mapper.Map<UserDto>(updatedModel);
        }

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _usersRepository.Delete(id);
        }
    }
}
