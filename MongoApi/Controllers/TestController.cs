using Microsoft.AspNetCore.Mvc;
using MongoApi.Domain;
using MongoApi.DTO;
using MongoApi.Repository.Book;
using MongoApi.Repository.User;

namespace MongoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;

        public TestController(IUserRepository userRepository, IBookRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO userDTO)
        {
            var user = new User() { Name = userDTO.name, Family = userDTO.family, BirthDate = userDTO.birthDate };

            await _userRepository.Add(user);
            return Ok();
        }
    }
}
