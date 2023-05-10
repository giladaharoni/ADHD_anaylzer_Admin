using ADHD_anaylzer_Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADHD_anaylzer_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepository repository;
        public UsersController(IUserRepository userRepository)
        {
            repository = userRepository;
        }

        [HttpGet("register")]
        public IActionResult Register(string username, string fullname,string password)
        {
            var foundedUser = repository.GetUserByUserName(username);
            if (foundedUser == null)
            {
                User user = new()
                {
                    UserName = username,
                    Password = password,
                    FullName = fullname
                };
                repository.AddUser(user);
                return Ok(user);
            } else
            {
                return BadRequest();
            }
        }

        [HttpGet("login")]
        public IActionResult Login(string username, string password)
        {
            var foundedUser = repository.GetUserByUserName(username);
            if (foundedUser != null && foundedUser.UserName == username && foundedUser.Password == password)
            {
                return Ok(foundedUser);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(string username, string fullname, string password)
        {
            User user = new()
            {
                UserName = username,
                Password = password,
                FullName = fullname
            };
            repository.UpdateUser(user);
            return Ok();

        }
        [HttpDelete("deleteAll")]
        public void DeleteData(string admin_password)
        {
            if (admin_password == "ADHD_analyzer_reset_all_everything#%$^")
            {
                repository.DeleteAll();
            }
        }
    }
}
