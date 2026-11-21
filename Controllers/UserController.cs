using ITQ2_BSIT32E1_Batoy_Nicholo.Data;
using ITQ2_BSIT32E1_Batoy_Nicholo.DTO.Users;
using Microsoft.AspNetCore.Mvc;

namespace ITQ2_BSIT32E1_Batoy_Nicholo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<List<GetUserResponse>> GetAll()
        {
            List<GetUserResponse> result = new List<GetUserResponse>();
            foreach (User user in _userRepository.GetAll())
            {
                result.Add(new GetUserResponse
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<GetUserByIdResponse> GetById(int id)
        {
            User? user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return Ok(new GetUserByIdResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            });
        }

        [HttpPost]
        public ActionResult<GetUserByIdResponse> Create([FromBody] CreateUserRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("User name is required.");
            }

            User newUser = _userRepository.Create(request.Name, request.Email);

            GetUserByIdResponse response = new GetUserByIdResponse
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email
            };

            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, response);
        }

        [HttpPut]
        public ActionResult<GetUserByIdResponse> Update([FromBody] EditUserRequest request)
        {
            if (request == null)
            {
                return BadRequest("User data is required.");
            }

            User? updatedUser = _userRepository.Update(request.Id, request.Name, request.Email);
            if (updatedUser == null)
            {
                return NotFound($"User with ID {request.Id} not found.");
            }

            return Ok(new GetUserByIdResponse
            {
                Id = updatedUser.Id,
                Name = updatedUser.Name,
                Email = updatedUser.Email
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = _userRepository.Delete(id);
            if (!deleted)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return NoContent();
        }
    }
}
