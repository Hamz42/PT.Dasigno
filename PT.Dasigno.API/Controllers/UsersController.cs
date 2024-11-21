using Microsoft.AspNetCore.Mvc;
using PT.Dasigno.BLL.Interfaces.Services;
using PT.Dasigno.DTO.Users;

namespace PT.Dasigno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _usersServices;

        public UsersController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_usersServices.GetAll());
        }

        [HttpPost("create")]
        public IActionResult Create(CreateUserRequest request)
        {
            return Ok(_usersServices.Create(request));
        }

        [HttpGet("find/{id}")]
        public IActionResult Find(int id)
        {
            return Ok(_usersServices.Find(id));
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateUserRequest request)
        {
            return Ok(_usersServices.Update(request));
        }

        [HttpPost("search")]
        public IActionResult Search(SearchUserRequest request)
        {
            return Ok(_usersServices.Search(request));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_usersServices.Delete(id));
        }
    }
}
