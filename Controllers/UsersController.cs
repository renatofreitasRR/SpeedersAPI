using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeedersAPI.Data;
using SpeedersAPI.Entities;
using SpeedersAPI.Repositories;
using SpeedersAPI.Repositories.Contracts;
using SpeedersAPI.Requests;

namespace SpeedersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginUserRequest loginRequest)
        {
            var user =_repository.GetByEmailAndPassword(loginRequest.Email, loginRequest.Password);

            if(user == null)
            {
                return Ok(new List<UserEntity>());
            }

            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(CreateUserRequest userRequest)
        {
            var user = new UserEntity(userRequest.Id, userRequest.UserName, userRequest.Password, userRequest.Email);

            _repository.Post(user);

            return Ok(userRequest);
        }

        [HttpPut]
        public IActionResult Put(UpdateUserRequest userRequest)
        {
            try
            {
                var user = _repository.GetById(userRequest.Id);
                user.SetUserName(userRequest.UserName);
                user.SetPassword(userRequest.Password);

                if(user.Errors.Count > 0)
                {
                    return BadRequest(new { Errors = user.Errors });
                }

                _repository.Update(user);

                return Ok(userRequest);
            }
            catch (Exception ex)
            {
                return BadRequest("Um erro ocorreu!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _repository.Delete(id);

            return Ok();
        }
    }
}
